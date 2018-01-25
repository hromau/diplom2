using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using diplom2.Models;
using System.Text.RegularExpressions;
using Ninject;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace diplom2.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(WebServicesContext context)
        {
            Startup.db = context;
        }

        //for registration. it is a necessery?
        static Regex pass_regex = new Regex(@"^\w+$");
        static Regex account_regex = new Regex(@"^\d{4}$");
        static Regex name_regex = new Regex(@"^[А-Я][а-я]+$");
        static Regex accountTeacher_regex = new Regex(@"^123455$");

        public UserTables tempUser;

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult LoginForm()
        {
            return View();
        }

        public void CheckLogin(string accountNumber, string password)
        {
            //if (accountNumber == "123" && password == "321")
            //{
            //    //View(GeneralForm());

            //    addToken(Response);
            //    Response.Redirect("/Home/GeneralForm/");

            //}
            //else
            //{
            //    Response.Redirect("/Home/Error/");
            //}
            //activeUser = Startup.AppKernel.Get<ModelActiveUser>(accountNumber);


            if (Startup.db.UserTables.Any(it => it.AccountNumber.Equals(accountNumber) && it.Password.Equals(password)))
            {
                ModelActiveUser tempUser = new ModelActiveUser(accountNumber);
                
                //выделение активного юзера
                //activeUser = Startup.item.UserTable.First(it => it.AccountNumber.Equals(accountNumber));

                //                Ninject.ActivationException
                //  HResult = 0x80131500
                //  Сообщение = Error activating ModelActiveUser
                //No matching bindings are available, and the type is not self - bindable.
                //Activation path:
                //  1) Request for ModelActiveUser

                //Suggestions:
                //  1) Ensure that you have defined a binding for ModelActiveUser.
                //  2) If the binding was defined in a module, ensure that the module has been loaded into the kernel.
                //  3) Ensure you have not accidentally created more than one kernel.
                //  4) If you are using constructor arguments, ensure that the parameter name matches the constructors parameter name.

                //activeUser = Startup.AppKernel.Get<ModelActiveUser>(accountNumber);
                //создание модели активного юзера

                //return View("Your account is valid!\nHello "+activeUser.FirstName);
                Response.Redirect("/Home/GeneralForm/");
            }
            else
                //возвращение об ошибке
                Response.Redirect("/Home/Error/");
            //return View("Your account is not valid!");


        }

        //Получение джейсона событий календаря get json of a events
        public string getCalendarEvents(string year, string month)
        {
            //получение из бд события 
            ArrayOfEvents.listEvents = Startup.db.Events.Where(it => it.Month.Equals(month) && it.Year.Equals(year)).ToList();

            //Внимание! Велосипед
            //foreach (var item in Startup.item.Event)
            //{
            //    if (item.Month.Equals(month) && item.Year.Equals(year))
            //    {
            //        ArrayOfEvents.Evs.Add(item);
            //    }
            //}

            return JsonConvert.SerializeObject(ArrayOfEvents.listEvents);
        }

        //Получение джейсона занятий get json a lessons 
        public string getLesson(string week, string groupName)
        {
            //ЧТЕНИЕ ИЗ БД РАСПИАНИЯ 
            ArrayOfLectures.listLectures = Startup.db.TimeTables.Where(t => t.Week.Equals(week) && t.Group.Equals(groupName)).ToList();

            return JsonConvert.SerializeObject(ArrayOfLectures.listLectures);
        }

        public string getLessonMini(string week, string group, string number)
        {
            ArrayOfLectures.listLectures = Startup.db.TimeTables.Where(t => t.Week == week && t.Group == group && t.SerialNumberLectures == number).ToList();

            return JsonConvert.SerializeObject(ArrayOfLectures.listLectures);
        }

        public string getStatements(string accountNumber)
        {
            ArrayOfStatements.listStatements = Startup.db.TableOfStatements.Where(item => item.AccountNumber == accountNumber).ToList();
            return JsonConvert.SerializeObject(ArrayOfStatements.listStatements);
        }

        //получение джейсона пользователя
        public string getUser(string accountNumber, string password)
        {
            tempUser = new UserTables();
            tempUser = Startup.db.UserTables.Where(t => t.AccountNumber == accountNumber && t.Password == password).First();
            return JsonConvert.SerializeObject(tempUser);
        }

        //получение всех студентов группы
        public string getAllUserGroup(string group)
        {
            ArrayOfAllUserGroup.listAllUserGroup = Startup.db.UserTables.Where(item => item.GroupName == group).ToList();
            return JsonConvert.SerializeObject(ArrayOfAllUserGroup.listAllUserGroup);
        }

        public IActionResult GeneralForm()//string accountNumber, string password)
        {
            //if (Startup.db.UserTables.Any(it => it.AccountNumber.Equals(accountNumber) && it.Password.Equals(password)))
            //{
            //    ModelActiveUser tempUser = new ModelActiveUser(accountNumber);
            //    //Response.Redirect("/Home/GeneralForm");
            //    return View(tempUser);
            //}
            //else
                //возвращение об ошибке
                //Response.Redirect("/Home/Error");
            return View();
            //return View(model);
        }

        public IActionResult RegistrationForm()
        {
            return View();
        }

        //метод для создания новоого юзера.то есть должно быть добавелние в бд
        public string NewUser(string lastName, string firstName, DateTime dob, string password, string accountNumber, string groupName, string email)
        {

            //bike 
            bool passValid = pass_regex.IsMatch(password);
            bool accountValid = account_regex.IsMatch(accountNumber);
            bool lastNameValid = name_regex.IsMatch(lastName);
            bool firstNameValid = name_regex.IsMatch(firstName);
            bool accountTeacherValid = accountTeacher_regex.IsMatch(accountNumber);
            //на мыло @
            bool emailValid = (email.Contains('@')) ? true : false;

            if (!passValid || !accountValid || !lastNameValid || !firstNameValid || !emailValid)
            {
                return "{\"ok\":false}";
            }
            else
            {
                UserTables ut = new UserTables();
                try
                {
                    ut.AccountNumber = accountNumber;
                    ut.Dob = dob;
                    ut.Email = email;
                    ut.FirstName = firstName;
                    ut.LastName = lastName;
                    ut.Password = password;
                    ut.GroupName = groupName;
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    return "{\"ok\":false}";
                }
                //вот тут мне не нравится проверочка. тип если в бд уже такой есть, то не писать снова. 
                //но ведь др может совпадать. хотя. он же проверяет объект с объектом. одно поле не сошлось значит не тру
                if (!Startup.db.UserTables.All(it => it.Equals(ut)))
                {
                    //try
                    Startup.db.UserTables.Add(ut);
                    Startup.db.SaveChanges();
                }
                return "{\"ok\":true}";
            }


        }

    }
}
