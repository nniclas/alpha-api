using Moq;
using alpha_api.Controllers;
using alpha_api.Models;
using alpha_api.Services;
using alpha_api.Core.Enums;

namespace alpha_api.Tests.Common
{
    public class MockData
    {
        public static IEnumerable<Unit> Units 
        { 
            get  
            { 
               return new List<Unit>
               {
                    new Unit
                    {
                        Id = 1,
                        MachineId = "a3626fd8-da27-4630-99a9-b6ef49415aa5",
                        Name = "Alpha",
                        State = 1
                    },
                     new Unit
                    {
                        Id = 2,
                        MachineId = "2d0cfd02-97de-4b12-be12-75454858b230",
                        Name = "Beta",
                        State = 2

                    },
                     new Unit
                    {
                        Id = 3,
                        MachineId = "692ae5f3-b986-4886-9160-3daf14ce03fa",
                        Name = "Omega",
                        State = 3

                    },
               };
            } 
        }

        public static IEnumerable<Entry> Entries
        {
            get
            {
                return new List<Entry>
               {
                    new Entry
                    {
                        Id = 1,
                        UnitId = 1,
                        UserId = 2,
                        Event = Event.ALERT,
                        Tag = Tag.DEVIATION_IDENTIFIED,
                        Measure = Measure.FOLLOW_UP,
                        Date = DateTime.Now,
                    },
                    new Entry
                    {
                        Id = 2,
                        UnitId = 1,
                        UserId = 1,
                        Event = Event.ROUTINE,
                        Tag = Tag.MONTHLY_FIELD_TEST,
                        Date = DateTime.Now,
                    },
                    new Entry
                    {
                        Id = 3,
                        UnitId = 2,
                        UserId = 1,
                        Event = Event.CRITICAL,
                        Tag = Tag.TEMP_LOW,
                        Date = DateTime.Now,
                    }
               };
            }
        }
    }
}