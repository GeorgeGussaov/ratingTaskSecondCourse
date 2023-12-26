using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ratingTask2
{
    internal static class Program
    {

        static IEnumerable<Lesson> Sort(this Schedule sch)  //1 задание
        {
            //for (int i = sch.listLesson.Count - 1; i > 0; i--)
            //{
            //    for (int j = 0; j < i; j++)
            //    {
            //        int currentNumber = sch.listLesson[j].Number;
            //        int nextNumber = sch.listLesson[j + 1].Number;
            //        if (sch.listLesson[j].Number > sch.listLesson[j + 1].Number && sch.listLesson[j].Day > sch.listLesson[j + 1].Day)   
            //        {
            //            Lesson current = sch.listLesson[j];
            //            sch.listLesson[j] = sch.listLesson[j + 1];        //при помощи сортировки пузырьком 
            //            sch.listLesson[j + 1] = current;
            //        }
            //    }
            //}
            //return sch;
            
            return sch.OrderBy(x => x.Number);  //при помощи Linq. Конечно функция работает не совсем как в задании
                                                //и возвращает перечисление Lessons а не Schedule, но я додумался только до такого :)
                                                //или можно раскоментить решение пузырьком выше, но это совсем грамосткое решение.
        }

        //2 задание не успеваю, но идея вроде есть. При помощи компарера.

        static void Main(string[] args)
        {
            Lesson les1 = new Lesson();
            Lesson les2 = new Lesson();
            Lesson les3 = new Lesson();
            Lesson lesMat = new Lesson("Матан", 1, 0, WeekDays.Monday, "11");
            Lesson lesAlg = new Lesson("Алгебра", 2, 1, WeekDays.Monday, "11");
            Lesson lesAlgPract = new Lesson("Алгебра", 2, 1, WeekDays.Monday, "21");
            //Console.WriteLine(lesMat);

            Schedule schedule = new Schedule("ФМиКН");
            schedule.Add(les3);
            schedule.Add(les2);
            schedule.Add(les1);
            schedule.Add(lesAlg);
            schedule.Add(lesAlgPract);
            schedule.Add(lesMat);
            Console.WriteLine(schedule);

            Console.WriteLine();
            Console.WriteLine();

            var newSchedule = schedule.Sort();
            foreach(var item in newSchedule)
            {
                Console.WriteLine(item);
            }
        }
    }

    
}
