namespace SerLiunx
{
    class Main
    {
        public static string GetExternalIp()
        {
            try
            {
                WebClient client = new WebClient();
                client.Encoding = System.Text.Encoding.Default;
                string response = client.DownloadString("http://ip.chinaz.com/");
                string myReg = @"<dd class=""fz24"">([\s\S]+?)<\/dd>";
                Match mc = Regex.Match(response, myReg, RegexOptions.Singleline);
                if (mc.Success && mc.Groups.Count > 1)
                {
                    response = mc.Groups[1].Value;
                    return response;
                }
                else
                {
                    return "error";
                }
            }
            catch (Exception)
            {
                return "error";
            }

        }

    }
}