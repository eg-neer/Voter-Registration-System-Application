using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Voter_Registration_System
{
    internal class Voter : Person
    {
        public string voterID { get; set; }
        public string Province { get; set; }
        public string muniCity { get; set; }
        public string Brgy { get; set; }
        public bool Status { get; set; }
        public int LastYearVoted { get; set; }
        public DateTime? RegisDate { get; set; }
        public Voter(string firstName, string lastName, DateTime birthday, char sex) : base(firstName, lastName, birthday, sex)
        {
            Status = true; //default status upon registration
            RegisDate = DateTime.Today;
            LastYearVoted = 0;
        }
        public void InputAddress()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("22. Cebu");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter Province: ");
            Province = Console.ReadLine();
            Province = Province.ToUpper();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("17. Cebu ");
            Console.WriteLine("23. Danao");
            Console.WriteLine("26. Lapu-lapu");
            Console.WriteLine("30. Mandaue");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Please choose City/Municipality: ");
            muniCity = Console.ReadLine();
            muniCity = muniCity.ToUpper();

            Console.WriteLine();
            if (muniCity == "CEBU")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("1. Adlaon                2. Agsungot             3. Apas                 4. Babag                5. Basak Pardo");
                Console.WriteLine("6. Bacayan               7. Banilad              8. Basak San Nicolas    9. Binaliw              10. Bonbon");
                Console.WriteLine("11. Budla-an             12. Buhisan             13. Bulacao             14. Buot-Taup Pardo     15. Busay");
                Console.WriteLine("16. Calamba              17. Cambinocot          18. Capitol Site        19. Carreta             20. Central");
                Console.WriteLine("21. Cogon Ramos          22. Cogon Pardo         23. Day-as              24. Duljo               25. Ermita");
                Console.WriteLine("26. Guadalupe            27. Guba                28. Hippodromo          29. Inayawan            30. Kalubihan");
                Console.WriteLine("31. Kalunasan            32. Kamagayan           33. Kamputhaw           34. Kasambagan          35. Kinasang-an Pardo");
                Console.WriteLine("36. Labangon             37. Lahug               38. Lorega              39. Lusaran             40. Luz");
                Console.WriteLine("41. Mabini               42. Mabolo              43. Malubog             44. Mambaling           45. Pahina Central");
                Console.WriteLine("46. Pahina San Nicolas   47. Pamutan             48. Pardo               49. Pari-an             50. Paril");
                Console.WriteLine("51. Pasil                52. Pit-os              53. Pulangbato          54. Pung-ol-Sibugay     55. Punta Princesa");
                Console.WriteLine("56. Quiot Pardo          57. Sambag I            58. Sambag II           59. San Antonio         60. San Jose");
                Console.WriteLine("61. San Nicolas Central  62. San Roque           63. Santa Cruz          64. Sawang Calero       65. Sinsin");
                Console.WriteLine("66. Sirao                67. Suba San Nicolas    68. Sudlon I            69. Sapangdaku          70. T. Padilla");
                Console.WriteLine("71. Tabunan              72. Tagbao              73. Talamban            74. Taptap              75. Tejero ");
                Console.WriteLine("76. Tinago               77. Tisa                78. To-ong Pardo        79. Zapatera            80. Sudlon II");

                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else if (muniCity == "DANAO")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("1. Baliang       2. Bayabas          3. Binaliw           4. Cabungahan      5. Cagat-Lamac");
                Console.WriteLine("6. Cahumayan     7. Cambanay         8. Cambubho          9. Cogon-Cruz      10. Danasan");
                Console.WriteLine("11. Dungga       12. Dunggoan        13. Guinacot         14. Guinsay        15. Ibo");
                Console.WriteLine("16. Langosig     17. Lawaan          18. Licos            19. Looc           20. Magtagobtob");
                Console.WriteLine("21. Malapoc      22. Manlayag        23. Mantija          24. Masaba         25. Maslog");
                Console.WriteLine("26. Nangka       27. Oguis           28. Pili             29. Poblacion      30. Quisol");
                Console.WriteLine("31. Sabang       32. Sacsac          33. Sandayong Norte  34. Sandayong Sur  35. Santa Rosa");
                Console.WriteLine("36. Santican     37. Sibacan         38. Suba             39. Taboc          40. Taytay");
                Console.WriteLine("41. Togonon      42. Tuburan Sur");
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else if (muniCity == "LAPU-LAPU")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("1. Agus          2. Babag          3. Bankal     4. Baring       5. Basak");
                Console.WriteLine("6. Buaya         7. Calawisan      8. Canjulao   9. Caw-oy       10. Cawhagan");
                Console.WriteLine("11. Caubian      12. Gun-ob        13. Ibo       14. Looc        15. Mactan");
                Console.WriteLine("16. Maribago     17. Marigondon    18. Pajac     19. Pajo        20. Pangan-an");
                Console.WriteLine("21. Poblacion    22. Punta Engaño  23. Pusok     24. Sabang      25. Santa Rosa");
                Console.WriteLine("26. Subabasbas   27. Talima        28. Tingo     29. Tungasan    30. San Vicente");
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else if (muniCity == "MANDAUE")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("1. Alang-alang     2. Bakilid          3. Banilad            4. Basak            5. Cabancalan");
                Console.WriteLine("6. Cambaro         7. Canduman         8. Casili             9. Casuntingan      10. Centro");
                Console.WriteLine("11. Cubacub        12. Guizo           13. Ibabao-Estancia   14. Jagobiao        15. Labogon");
                Console.WriteLine("16. Looc           17. Maguikay        18. Mantuyong         19. Opao            20. Pakna-an");
                Console.WriteLine("21. Pagsabungan    22. Subangdaku      23. Tabok             24. Tawason         25. Tingub");
                Console.WriteLine("26. Tipolo         27. Umapad");
                Console.ForegroundColor = ConsoleColor.Yellow;
            }

            Console.Write("Please enter barangay: ");
            Brgy = Console.ReadLine();
            Brgy = Brgy.ToUpper();
        }
        public void UpdateStatus(bool newStatus)
        {
            Status = newStatus;
        }
    }
}
