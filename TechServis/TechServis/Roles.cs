using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechServis
{
    public class Roles
    {
        int id;
        bool ad, man;

        //Присвоение айди
        public void SetID(int iid)
        {
            id = iid;
        }

        //Возращение айди
        public int GetID() { return id; }

        //Присвоение значения роли администротора
        public void SetAd(bool aad) 
        {
            ad = aad;
        }

        //Присвоение значения роли менеджер
        public void SetMan(bool maan)
        {
            man = maan;
        }

        //Возращение Роли
        public string GetRole() 
        {
            string role;

            if (ad)
            {
                role = "admin";
            }
            else
            {
                if (man)
                {
                    role = "manager";
                }
                else
                {
                    role = "master";
                }
            }

            return role;
        }
    }
}
