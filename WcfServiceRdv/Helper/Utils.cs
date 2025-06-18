using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfServiceRdv.Models;

namespace WcfServiceRdv.Helper
{
    public class Utils
    {

        BdRvMedicalContext db = new BdRvMedicalContext();
        /// <summary>
        /// Cette methode nous permet de logger en bdd
        /// </summary>
        /// <param name="TitreErreur">Titre de l'erreur</param>
        /// <param name="erreur">Message de l'erreur</param>
        public void WriteDataError(string TitreErreur, string erreur)
        {
            try
            {
                Td_Erreur log = new Td_Erreur();
                log.DateErreur = DateTime.Now;
                log.DescriptionErreur = erreur.Length > 2000 ? erreur.Substring(0, 2000) : erreur;
                log.TitreErreur = TitreErreur;
                db.Td_Erreur.Add(log);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                WriteLogSystem(ex.ToString(), "WriteDataError");
            }
        }

        /// <summary>
        /// Cette methode nous permet de logger sur le systeme
        /// </summary>
        /// <param name="erreur">Titre de l'erreur</param>
        /// <param name="libelle">Message de l'erreur</param>
        public static void WriteLogSystem(string erreur, string libelle)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "AppGestionRendezVous";
                eventLog.WriteEntry(string.Format("date: {0}, libelle: {1}, description {2}", DateTime.Now, libelle, erreur), EventLogEntryType.Information, 101, 1);
            }
        }

        /// <summary>
        /// Cette methode nous permet de logger sur un fichier 
        /// </summary>
        /// <param name="message">Le message de log</param>
        public static void WriteFileError(string message)
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Error", "erreur.txt");

               
                string directory = Path.GetDirectoryName(path);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                using (StreamWriter writeFile = new StreamWriter(path, true))
                {
                    writeFile.WriteLine($"{DateTime.Now}");
                    writeFile.WriteLine(message);
                    writeFile.WriteLine("------------------------------------------------------");
                }
            }
            catch (IOException e)
            {
                WriteLogSystem(e.ToString(), "WriteFileError");
            }
        }

        /// <summary>
        /// Cette méthode permet de logger une action utilisateur en base de données.
        /// </summary>
        public void LogUserAction(string user, string action)
        {
            try
            {
                Td_Erreur log = new Td_Erreur();
                log.DateErreur = DateTime.Now;
                log.DescriptionErreur = $"Utilisateur: {user}, Action: {action}";
                log.TitreErreur = "Action Utilisateur";
                db.Td_Erreur.Add(log);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                WriteLogSystem(ex.ToString(), "LogUserAction");
            }
        }
        /// <summary>
        /// Cette log permet de logger les exceptions non gérées au niveau global
        /// </summary>
        public static void RegisterGlobalExceptionHandler()
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                WriteLogSystem(e.ExceptionObject.ToString(), "UnhandledException");
                WriteFileError(e.ExceptionObject.ToString());
            };
        }

        /// <summary>
        /// Cette log permet de mesurer les performances de notre app 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="action"></param>
        public static void LogPerformance(string operation, Action action)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            action();
            stopwatch.Stop();
            WriteLogSystem($"Temps d'exécution: {stopwatch.ElapsedMilliseconds}ms", operation);
        }

        /// <summary>
        /// Methode de log en mode debug qui s'affiche uniquement en mode développement
        /// </summary>
        /// <param name="message"></param>
#if DEBUG
        public static void DebugLog(string message)
        {
            Console.WriteLine($"[DEBUG] {DateTime.Now}: {message}");
        }
#endif
    


}
}

