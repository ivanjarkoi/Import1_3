using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Import
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Impotr();
        }
        private void Impotr()
        {
            var fileData = File.ReadAllLines(@"D:\СмолАПО\4курс\Зимняя сессия\МДК01.01\Точтосделал\Team2.txt");
            var image = Directory.GetFiles(@"D:\СмолАПО\4курс\Зимняя сессия\МДК01.01\TP09_2018_2D_NBA\Ресурсы\Сессия 1\data\Teams");
           
            foreach (var line in fileData)
            {
                var dan = line.Split('\t');
               
                var tempTour = new Team
                {
     
        TeamName=dan[0].Replace("\"", ""),
        DivisionId=int.Parse(dan[1]),
        Coach=dan[2].Replace("\"", ""),
        Abbr=dan[3],
        Stadium=dan[4].Replace("\"", ""),
        Logo= Encoding.UTF8.GetBytes(dan[5])
         
                  
          
                };
                Entities.Got().Teams.Add(tempTour);

                Entities.Got().SaveChanges();
            }
        }
    }
}
/*
                var t = dan[3].Split('-');
                var r = dan[6].Split('-');         
                var te =t[2] + "/" + t[1] + "/" + t[0] ;
                var rt = r[2] + "/" + r[1] + "/" + r[0];
          
 
    Name = dan[1].Replace("\"",""),
            PositionId = int.Parse(dan[2]),
           JoinYear = DateTime.Parse(te),
            Height=decimal.Parse(dan[4]),
            Weight=decimal.Parse(dan[5]),
            DateOfBirth= DateTime.Parse(rt),
            College=dan[7].Replace("\"", ""),
            CountryCode=dan[8].Replace("\"", ""),
            Img=Encoding.UTF8.GetBytes(dan[9]),
            IsRetirment=(dan[10]=="ЛОЖЬ") ? false: true,
 
 */