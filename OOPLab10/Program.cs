using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;

using System.Reflection;
using System.IO;

namespace OOPLab10
{
    
    class Program
    {
        static void Main(string[] args)
        {

            A a = new A(1);
            Reflector.GetClassInfo(a);
            Console.WriteLine();
            Console.WriteLine();
            Reflector.GetPublicMetods();
            Console.WriteLine();
            Console.WriteLine();
            Reflector.GetField();
            Console.WriteLine();
            Console.WriteLine();
            Reflector.GetMet( 5.GetType());
            Console.WriteLine();
            Console.WriteLine("-------------------------------");
            Reflector.GetAssem();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("-------------------------------");
            Reflector.GetInterfase();
            Console.WriteLine();
            Console.WriteLine();
            Reflector.Call();
            Console.ReadKey();
        }

        static class Reflector
        {
            public static void GetClassInfo(A d)
            {
                Type tt = typeof(A);
                var bf = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance;


                foreach (MethodInfo mi in tt.GetMethods(bf))
                {
                    Console.WriteLine("Method Name = " + mi.Name);
                    Console.WriteLine("Method Return Type = " + mi.ReturnType);
                    foreach (ParameterInfo pr in mi.GetParameters())
                    {
                        Console.WriteLine("Parameter Name = " + pr.Name);
                        Console.WriteLine("Type = " + pr.ParameterType);
                    }
                }
                Console.WriteLine();
                Console.WriteLine();

                foreach (MemberInfo mi in tt.GetMembers(bf))
                {
                    Console.WriteLine("Method Name = " + mi.Name);

                }



            }

            public static void GetPublicMetods()
            {
                Type tt = typeof(A);
                var bf =  BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance;

                foreach (MemberInfo mi in tt.GetMembers(bf))
                {
                    Console.WriteLine("Method Name = " + mi.Name);
                }
            }

            public static void GetField()
            {
                Type tt = typeof(A);
                var bf = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance;

                foreach (PropertyInfo mi in tt.GetProperties(bf))
                {
                    Console.WriteLine("Property Name = " + mi.Name);
                    Console.WriteLine("Property Type = " + mi.PropertyType);
                    Console.WriteLine("IsSpecialName = " + mi.IsSpecialName);


                }
                foreach (FieldInfo mi in tt.GetFields(bf))
                {
                    Console.WriteLine("Property Name = " + mi.Name);
                    Console.WriteLine("IsStatic = " + mi.IsStatic);
                    Console.WriteLine("IsSpecialName = " + mi.MemberType);


                }

            }

            public static void GetInterfase()
            {
                Type tt = typeof(A);

                foreach(MemberInfo i in  tt.GetInterfaces())
                {
                    Console.WriteLine("Interface = "+i);
                }

            }

            public static void GetMet(Type st)
            {
                Type tt = typeof(A);
                var bf = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance;

                foreach (MethodInfo mi in tt.GetMethods(bf))
                {

                    foreach (ParameterInfo pr in mi.GetParameters())
                    {

                        if (pr.ParameterType.Equals(st))
                        {
                            Console.WriteLine("Method Name = "+mi.Name);
                            break;
                        }

                    }


                }
            }

            public static void Call()
            {
                StreamReader read = new StreamReader(@"C:\Users\User\Desktop\Lab OOP\Lab12\OOPLab10\bin\Debug\Par.txt");

                object[] Par=new object[2];
                Par[0] = Int32.Parse(read.ReadLine());
                Par[1] = Int32.Parse(read.ReadLine());

                Assembly asm = Assembly.LoadFrom("C:\\Users\\User\\Desktop\\Lab OOP\\Lab12\\OOPLab10\\bin\\Debug\\OOPLab10.exe");

                Type[] type = asm.GetTypes();
                var bf =  BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance;

                foreach (Type tt in type)
                {

                    foreach (MethodInfo mi in tt.GetMethods(bf))
                    {
                        if (mi.Name.Equals("sum"))
                        {
                            object obj = Activator.CreateInstance(tt,32);
                            object res = mi.Invoke(obj,Par);
                            return;
                        }
                    }
                    Console.WriteLine();




                }


            }

            public static void GetAssem()
            {
                Assembly asm = Assembly.LoadFrom("C:\\Users\\User\\Desktop\\Lab OOP\\Lab12\\OOPLab10\\bin\\Debug\\Ass.exe");

                Type[] typ = asm.GetTypes();
                var bf = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance;

                foreach (Type tt in typ)
                {

                    Console.WriteLine("====="+tt.Name+"=====");
                    foreach (MethodInfo mi in tt.GetMethods(bf))
                    {
                        Console.WriteLine("Method Name = " + mi.Name);
                        Console.WriteLine("Method Return Type = " + mi.ReturnType);
                        foreach (ParameterInfo pr in mi.GetParameters())
                        {
                            Console.WriteLine("Parameter Name = " + pr.Name);
                            Console.WriteLine("Type = " + pr.ParameterType);
                        }
                    }
                    Console.WriteLine();
                 

                  

                }
            }

        }

        interface IInt
        {
             void sum3();
            void sum2(string x, int y);

        }



        class A : IInt
        {

            public A(int x)
                {
                i = x;                
                }
            
            private int i = 10;
            public int j = 0;
            public int I
            { get { return i; } }

            public int J
            { set {  J=value; } }


            public  void sum(int x,int y)
            {
               
                Console.WriteLine("Sum = "+(x+y+i));
            }
            public void sum2(string x, int y)
            {
            }
            public void sum3()
            {
            }
            private  void FunI()
            {
                i++;
            }
            public  void MyType()
            {
                Console.WriteLine(typeof(A));
            }

        }








///////////////////////
    }
}
