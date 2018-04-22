using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WFA_blth_n_tray
{
    class NetFunctions
    {

        public static byte[] getSynhronizationBytes()
        {
            return new byte[] { byte.MinValue, byte.MinValue, byte.MinValue, byte.MinValue, byte.MinValue, byte.MinValue, byte.MinValue, byte.MinValue, byte.MinValue, byte.MinValue,
                                byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue};
        }

        public static bool isFailSynhronizationTest(byte[] bytes)
        {
            for (int i = 0; i < 20; ++i)
            {
                if (i < 10)
                {
                    if (bytes[i] != byte.MinValue)
                        return true;
                }
                else
                {
                    if (bytes[i] != byte.MaxValue)
                        return true;
                }
            }
            return false;
        }

        public static Task<string> ReadString(NetworkStream stream, CancellationTokenSource CancellationToken)
        {
            Task<string> task = new Task<string>(() =>
            {
                int emptySteps = 0;
                int emptyStepsTrashold = 1000;

                bool isFailSynchronization = false;

                if (CancellationToken.Token.IsCancellationRequested) return null;
                byte[] int32Size = new byte[4];
                var res1 = stream.BeginRead(int32Size, 0, 4, null, null);
                emptySteps = 0;
                while (!res1.IsCompleted)
                {
                    if (CancellationToken.Token.IsCancellationRequested)
                    {
                        res1.AsyncWaitHandle.Close();
                        return null;
                    }
                    emptySteps += 1;
                    Thread.Sleep(0);
                    if (emptySteps > emptyStepsTrashold)
                    {
                        emptySteps = 0;
                        Thread.Sleep(1);
                    }
                }
                //res1.AsyncWaitHandle.WaitOne();
                var Length = BitConverter.ToInt32(int32Size, 0);
                if (Length > 100 * 1024)
                    isFailSynchronization = true;
                byte[] stringJson = null;
                if (!isFailSynchronization)
                {
                    stringJson = new byte[Length];
                    var res2 = stream.BeginRead(stringJson, 0, Length, null, null);

                    emptySteps = 0;
                    while (!res2.IsCompleted)
                    {
                        if (CancellationToken.Token.IsCancellationRequested)
                        {
                            res2.AsyncWaitHandle.Close();
                            return null;
                        }
                        emptySteps += 1;
                        Thread.Sleep(0);
                        if (emptySteps > emptyStepsTrashold)
                        {
                            emptySteps = 0;
                            Thread.Sleep(1);
                        }
                    }
                }
                //synhronization read
                if (!isFailSynchronization)
                {
                    byte[] synhronizationByte = new byte[20];
                    var res3 = stream.BeginRead(synhronizationByte, 0, 20, null, null);

                    emptySteps = 0;
                    while (!res3.IsCompleted)
                    {
                        if (CancellationToken.Token.IsCancellationRequested)
                        {
                            res3.AsyncWaitHandle.Close();
                            return null;
                        }
                        emptySteps += 1;
                        Thread.Sleep(0);
                        if (emptySteps > emptyStepsTrashold)
                        {
                            emptySteps = 0;
                            Thread.Sleep(1);
                        }
                    }

                    isFailSynchronization = isFailSynhronizationTest(synhronizationByte);
                }
                //res2.AsyncWaitHandle.WaitOne();
                if (!isFailSynchronization)
                {
                    //success
                    return System.Text.Encoding.UTF8.GetString(stringJson);
                }
                //recover synchronization
                byte[] synhronizationByte2 = new byte[20];
                var res4 = stream.BeginRead(synhronizationByte2, 0, 20, null, null);

                emptySteps = 0;
                while (!res4.IsCompleted)
                {
                    if (CancellationToken.Token.IsCancellationRequested)
                    {
                        res4.AsyncWaitHandle.Close();
                        return null;
                    }
                    emptySteps += 1;
                    Thread.Sleep(0);
                    if (emptySteps > emptyStepsTrashold)
                    {
                        emptySteps = 0;
                        Thread.Sleep(1);
                    }
                }
                //try byte by byte
                while (isFailSynhronizationTest(synhronizationByte2))
                {
                    byte[] oneByte = new byte[1];
                    var res5 = stream.BeginRead(oneByte, 0, 1, null, null);

                    emptySteps = 0;
                    while (!res5.IsCompleted)
                    {
                        if (CancellationToken.Token.IsCancellationRequested)
                        {
                            res5.AsyncWaitHandle.Close();
                            return null;
                        }
                        emptySteps += 1;
                        Thread.Sleep(0);
                        if (emptySteps > emptyStepsTrashold)
                        {
                            emptySteps = 0;
                            Thread.Sleep(1);
                        }
                    }

                    for (int i = 0; i < getSynhronizationBytes().Count(x => true); ++i)
                        if (i > 0)
                            synhronizationByte2[i - 1] = synhronizationByte2[i];
                    synhronizationByte2[getSynhronizationBytes().Count(x => true) - 1] = oneByte[0];
                }
                return null;
            }, CancellationToken.Token);
            task.Start();
            return task;
        }

        public static void WriteString(NetworkStream stream, string json)
        {
            lock (stream)
            {
                var byteArr = Encoding.UTF8.GetBytes(json);
                var byteLength = BitConverter.GetBytes(byteArr.Length);
                stream.Write(byteLength, 0, byteLength.Length);
                stream.Write(byteArr, 0, byteArr.Length);
                //synchroning bytes
                stream.Write(getSynhronizationBytes(), 0, getSynhronizationBytes().Count(x=>true));
            }
        }
    }
}
