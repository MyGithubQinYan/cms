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
        /// 程序入口main方法
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args) //调用下面的连个方法，返回一个IHostBuild对象
                .Build()//用IHostBuilder对象传教一个IWebHost
                .Run();//用IWebHost启动一个一直监听Http请求的的任务。
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext,config)=> {///通过新增此方法，加载自己编写的配置信息
                    var env = hostingContext.HostingEnvironment;

                    config.AddJsonFile("appsetings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsetings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                    .AddJsonFile("Content.json", optional: true, reloadOnChange: false)
                    .AddEnvironmentVariables();
                })
                .ConfigureWebHostDefaults(webBuilder =>//使用默认配置信息初始化一个IWebHostBuilder对象。
                {
                    webBuilder.UseStartup<Startup>();//为webHost指定启动类startup。
                });
    }
}
