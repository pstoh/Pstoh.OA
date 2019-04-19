using System;

namespace Spring.Net.Test
{
    public class EFUserInfoDal:IUserInfoDal
    {

        public void Show()
        {
            Console.WriteLine("EFUserInfoDal  "+Name);
        }


        public string Name { get; set; }
    }
}