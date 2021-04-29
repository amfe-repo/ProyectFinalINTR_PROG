namespace comp.interfaces
{
    public interface IConection
    {   
        void createInfo(params dynamic[] list);
        void readInfo(params dynamic[] list);
        void updateInfo(params dynamic[] list);
        void deleteInfo(params dynamic[] list);
    }
}