using System;

namespace comp
{
    public class User
    {
        private string id = "";
        private string name = "";
        private string password = "";
        private string money = "";
        private string active = "";

        XmlConection xml_interface = new XmlConection();

        public User(string id, string name, string password, int money, int active)
        {
            this.id = id.ToString();
            this.password = password;
            this.name = name;
            this.money = money.ToString();
            this.active = active.ToString();   
        }

        public void addUserDB()
        {
            xml_interface.createInfo(this.id, this.name, this.password, this.money, this.active);
        }

        public bool verifyUserDB()
        {
            foreach (string item in xml_interface.verifyInfo("", "name", "name"))
            {
                if (this.name == item) return true;
            }

            return false; 
        }

        public void updateUserDBName(string condition_id, string name)
        {
            xml_interface.updateInfo(condition_id, this.id, name, this.money, this.active);
        }

        public void updateUserDBMoney(string condition_id, int money)
        {
            xml_interface.updateInfo(condition_id, this.id, this.name, money.ToString(), this.active);
        }

        public void updateUserDBActive(string condition_id, bool active)
        {
            xml_interface.updateInfo(condition_id, this.id, this.name, this.money, active.ToString());
        }

        //Setters

        public string getName () => this.name;
        public string getMoney () => this.money;

    }
}