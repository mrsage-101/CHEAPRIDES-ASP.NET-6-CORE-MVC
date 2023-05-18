using System;
using CHEAPRIDES.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;


namespace CHEAPRIDES.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context?.Database.EnsureCreated();

                //PersonInfo
                if(!context.Persons.Any() && !context.PersonLogin.Any() && !context.CarRegShows.Any() && !context.RideBookings.Any())
                {
                    /*context.Persons.AddRange(new List<PersonInfo>()
                    {
                          new PersonInfo()
                          {
                              Name = "Abubakar Siddique",
                              Username = "bakar204b",
                              Password = "asus204b",
                              Address = "WAPDA CITY 204-B B-BLOCK",
                              Contact = "3019666199",
                              type = 'C'
                          }
                    });*/
                    var personInfo = new PersonInfo()
                    {
                        Name = "Abubakar Siddique",
                        Username = "bakar204b",
                        Password = "asus204b",
                        Address = "WAPDA CITY 204-B B-BLOCK",
                        Contact = "3019666199",
                        type = "C"
                    };
                    context.Persons.Add(personInfo);
                    context.SaveChanges();

                    personInfo = context.Persons.FirstOrDefault(p => p.Username == "bakar204b");
                    context.PersonLogin.Add(new PersonLogin
                    {
                        pId = personInfo.pId,
                        Username = personInfo.Username,
                        Password = personInfo.Password,
                        type = personInfo.type
                    });
                    context.SaveChanges();

                    context.CarRegShows.Add(new CarRegShow()
                    {
                        cName = "HONDA",
                        cModel = "City",
                        cMake = "2018",
                        cRegNum = "FEA - 506",
                        pId = personInfo.pId,
                        type = personInfo.type
                    });
                    context.SaveChanges();
                    var car = context.CarRegShows.FirstOrDefault(p => p.cModel == "City");
                    context.RideBookings.Add(new RideBooking()
                    {
                        Pickuplocation = "FAST UNIVERSITY",
                        Droplocation = "WAPDACITY",
                        Fare = 500,
                        Carid = car.Carid
                    });
                    context.SaveChanges();
                }
                
                //CarRegShow
                /*if (!context.CarRegShows.Any())
                {
                    context.CarRegShows.AddRange(new List<CarRegShow>()
                    {
                        new CarRegShow()
                        {
                            cName = "Honda",
                            cModel = "City",
                            cMake = "2018",
                            cRegNum = "FEA - 5018",
                            pId = 1,
                            type = 'C'
                        }
                    });
                    context.SaveChanges();
                }*/

                //RideBooking
                /*if (!context.RideBookings.Any())
                {
                    context.RideBookings.AddRange(new List<RideBooking>()
                    {
                        new RideBooking()
                        {
                            Pickuplocation = "FAST UNIVERSITY",
                            Droplocation = "WAPDA CITY",
                            Fare = 500,
                            Carid = 1
                        }
                    });
                    context.SaveChanges();
                }*/
            }
        }
    }
}
