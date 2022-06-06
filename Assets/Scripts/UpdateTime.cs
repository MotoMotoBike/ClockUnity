using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using UnityEngine;

public class UpdateTime : MonoBehaviour
{
    public static DateTime GetDateTime() //  Получение Datetime
    {
        string[] servers = {
        "time.nist.gov",
        "time-a-g.nist.gov",
        "time-b-g.nist.gov"
        };
        
        using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
        {
            while (true)
            {
                try
                {
                    socket.Connect(servers[UnityEngine.Random.Range(0, servers.Length)], 13);
                    using (StreamReader rstream = new StreamReader(new NetworkStream(socket)))
                    {
                        string value = rstream.ReadToEnd().Trim();
                        MatchCollection matches = Regex.Matches(value, @"((\d*)-(\d*)-(\d*))|((\d*):(\d*):(\d*))");
                        string[] dd = matches[0].Value.Split('-');
                        return DateTime.Parse($"{matches[1].Value} {dd[2]}.{dd[1]}.{dd[0]}");
                    }
                }
                catch
                {

                }
            }
        }
    }
}
