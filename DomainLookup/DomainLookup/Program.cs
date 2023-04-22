using System;
using System.Net;
using System.Net.Sockets;

class Program
{
    static void Main(string[] args)
    {
        string domain = "google.com";
        IPHostEntry hostEntry = Dns.GetHostEntry(domain);

        Console.WriteLine("Domain: " + hostEntry.HostName);

        Console.WriteLine("\nIP addresses:");
        foreach (IPAddress address in hostEntry.AddressList)
        {
            Console.WriteLine("    " + address);
        }

        Console.WriteLine("\nMX records:");
        foreach (string mx in GetMxRecords(domain))
        {
            Console.WriteLine("    " + mx);
        }

        Console.ReadLine();
    }

    static string[] GetMxRecords(string domain)
    {
        string[] mxRecords = new string[0];

        try
        {
            // Get the MX records for the domain
            mxRecords = Dns.GetHostEntry(domain).HostName.Split('.');

            if (mxRecords.Length > 1)
            {
                Array.Reverse(mxRecords);
                Array.Resize(ref mxRecords, mxRecords.Length - 1);
                Array.Reverse(mxRecords);
            }
            else
            {
                mxRecords = new string[0];
            }
        }
        catch (SocketException ex)
        {
            Console.WriteLine("Error getting MX records: " + ex.Message);
        }

        return mxRecords;
    }
}
