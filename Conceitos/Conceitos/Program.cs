using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conceitos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region ENVIROMENT
            // Obtendo informações do sistema

            // Pegando o caminho da pasta "Meus documentos".
            var pastaDocumetos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Retornando o diretório atual.
            var diretorioAtual = Environment.CurrentDirectory;

            // Realizando uma quebra de linha
            var quebrandoLinha = Environment.NewLine;

            var nomeDominio = Environment.OSVersion;

            //Caminho das variáveis de ambiente
            var variavelAmbiente = Environment.GetEnvironmentVariable("Path");

            string[] discosRigidos = Environment.GetLogicalDrives();

            foreach(var disco in discosRigidos)
            {
                Console.WriteLine(disco);
            }

            var cpu = Environment.ProcessorCount;
            #endregion


            #region INICIANDO UMA TASK
            // Maneiras de iniciar uma task:
            //Task t1 = new Task(Tarefa);
            //t1.Start();

            //Task.Factory.StartNew(Tarefa);

            //Task.Run(() =>
            //{
            //    for(int i = 0; i < 10; i++)
            //    {
            //        Console.WriteLine("Task anônima");
            //    }
            //});

            //for(int i = 0;i < 10; i++)
            //{
            //    Console.WriteLine("Principal");
            //}
            #endregion

            #region TASK - Aguardando que uma tarefa seja executada para rodar outra
            // 1-  Aguarda as tarefas que foram passadas por parâmetro terminarem de executar para printar essa mensagem. 
            Task[] tasks =
            {
                Task.Factory.StartNew(()=>{
                    Console.WriteLine("Primeiro TASK");
                }),
                Task.Factory.StartNew(()=>{
                    Console.WriteLine("Segundo TASK");
                }),
                Task.Factory.StartNew(()=>{
                    Console.WriteLine("Terceira TASK");
                }),
            };
            Task.WaitAll(tasks);

            // 2 -  Aguarda as tarefas que foram passadas por parâmetro terminarem de executar para printar essa mensagem.
            Task t1 = Task.Run(() => { Console.WriteLine("Rodando #1"); });
            Task t2 = Task.Run(() => { Console.WriteLine("Rodando #2"); });
            
            Task.WaitAll(t1,t2);


            Console.WriteLine("Principal");
            #endregion



            string[] formats = {"d"};
            CultureInfo[] cultures = {  CultureInfo.CreateSpecificCulture("de-DE")};
            DateTime dateToDisplay = DateTime.Now;

            foreach (string formatSpecifier in formats)
            {
                foreach (CultureInfo culture in cultures)
                    Console.WriteLine(dateToDisplay.ToString(formatSpecifier, culture));
                    Console.WriteLine();
            }
            
            Console.ReadKey();
        }

        static private void Tarefa()
        {
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine("Tarefa do task");
            }
        }
    }
}
