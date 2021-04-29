namespace comp
{
    public class Amortization
    {
        public int id = 0;
        //public string payment_date = "";
        public double init_fee = 0.0;
        public double fee = 0.0;
        public double interest = 0.0;
        public double stock = 0.0;
        public double balance = 0.0;

        public Amortization(int id = 0, double init_fee = 0.0, double fee = 0.0, double interest = 0.0,
         double stock = 0.0, double balance = 0.0)
        {
            this.id = id;
            //this.payment_date = payment_date;
            this.init_fee = init_fee;
            this.fee = fee;
            this.interest = interest;
            this.stock = stock;
            this.balance = balance;
        }
    }
}