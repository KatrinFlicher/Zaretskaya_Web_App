using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zaretskaya_Html_Intro.DAL.Data;
using Zaretskaya_Html_Intro.DAL.Entities;

namespace Zaretskaya_Html_Intro.Tests
{
    public class TestData
    {

        public static void FillContext(ApplicationDbContext context)
        {
            context.DrugGroups.Add(new DrugGroup { Name = "fake group" });

            context.AddRange(new List<Drug>
            {
                new Drug{ Id=1, GroupId=1},
                new Drug{ Id=2, GroupId=1},
                new Drug{ Id=3, GroupId=2},
                new Drug{ Id=4, GroupId=2},
                new Drug{ Id=5, GroupId=3},
            });
            context.SaveChanges();
        }


        public static List<Drug> GetDrugList()
        {
            return new List<Drug>
            {
                new Drug{ Id=1, GroupId=1},
                new Drug{ Id=2, GroupId=1},
                new Drug{ Id=3, GroupId=2},
                new Drug{ Id=4, GroupId=2},
                new Drug{ Id=5, GroupId=3},
            };
        }

        public static IEnumerable<object[]> Params()
        {
            //1-я страница, кол-во объектов 3, id первого объекта 1
            yield return new object[] { 1, 3, 1 };
            yield return new object[] { 2, 2, 4 };
        }
    }
}