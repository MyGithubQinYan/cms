using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace cms
{
    public class Program
    {
        /// <summary>
        /// �������main����
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args) //�����������������������һ��IHostBuild����
                .Build()//��IHostBuilder���󴫽�һ��IWebHost
                .Run();//��IWebHost����һ��һֱ����Http����ĵ�����
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext,config)=> {///ͨ�������˷����������Լ���д��������Ϣ
                    var env = hostingContext.HostingEnvironment;

                    config.AddJsonFile("appsetings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsetings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                    .AddJsonFile("Content.json", optional: true, reloadOnChange: false)
                    .AddEnvironmentVariables();
                })
                .ConfigureWebHostDefaults(webBuilder =>//ʹ��Ĭ��������Ϣ��ʼ��һ��IWebHostBuilder����
                {
                    webBuilder.UseStartup<Startup>();//ΪwebHostָ��������startup��
                });
    }
}
