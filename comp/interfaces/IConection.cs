namespace comp.interfaces
{
    public interface IConection
    {   
        void createInfo(string condition, params dynamic[] list);
        void readInfo(params dynamic[] list);
        void updateInfo(string condition = "", params dynamic[] list);
        void deleteInfo(params dynamic[] list);
    }
}