using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Form112Console {
    internal class Program {

        private static string _picDirectory = @"C:\Users\etudiant\Documents\GitHub\Form112\Form112\Uploads\Bateaux";
        //private static string UnusedDir = @"C:\Users\etudiant\Documents\GitHub\Form112\Form112\Uploads\Bateaux\NotUsed";
        private static Form112Entities DB = new Form112Entities();


        static void Main(string[] args) {

            Console.Write(SetPictures());
            Console.ReadKey(true);
        }

        private static int SetPictures()
        {

            var list = DB.Croisieres.Where(v => !v.Photos.Any()).ToList();

            Console.WriteLine(list.Count);

            var listPic = Directory
                .GetFiles(_picDirectory)
                .Select(f => new FileInfo(f).Name)
                .ToList();

            var stackPic = new Stack<string>();
            foreach (var item in listPic)
            {
                if(item.Contains(""))
                stackPic.Push(item);
            }

            var cpt = 0;

            foreach (var croisieres in list)
            {
                if (stackPic.Count != 0)
                {
                    cpt++;
                    Console.Write(" {0} -", cpt);
                    var photo = new Photos
                    {
                        PhotoName = stackPic.Pop(),
                        IdPhoto = Guid.NewGuid()
                    };
                    croisieres.Photos.Add(photo);

                    if (cpt % 250 != 0)
                    {
                        continue;
                    }

                    cpt = 0;
                    Console.WriteLine();
                    DB.SaveChanges();
                }
            }

            DB.SaveChanges();
            return list.Count;
        }
    }
}
