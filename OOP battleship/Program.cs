//class Space_Object
//private name
//private hit_points
//procedure new(myname, myhit_points)
// name = myname
// hit_points = myhit_points
using System.Data.SqlTypes;
using System.Xml.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        Alien_ship[] ships = new Alien_ship[10];//array of 10 ships

        StreamReader file = new StreamReader("../../../resources/ships.txt");//open streamreader
        {
            for (int i = 0; i < ships.Length; i++) //loop through the file storing groups to temp
            {
                string tempName = file.ReadLine();
                int tempHP = Convert.ToInt32(file.ReadLine());
                int tempSpeed = Convert.ToInt32(file.ReadLine());
                int tempDamage = Convert.ToInt32(file.ReadLine());
                bool tempFriendly = Convert.ToBoolean(file.ReadLine());
                ships[i] = new Alien_ship(tempName, tempHP, tempSpeed, tempDamage, tempFriendly);//instantiate new alienship from temp
            }
        }
        file.Close();//close the file

        find_ships(ships,  10, 100, false);
    }
    public static void find_ships(Alien_ship[] ships,int speed, int damage, bool friendly)
    {
        for (int i = 0; i < ships.Length; i++)
        {
            if (ships[i].getspeed() == speed && ships[i].getdamage() == damage && ships[i].getfriendly() == friendly)
            {
                Console.WriteLine("ship name: {0} hp: {1} speed: {2} damage:{3} friendly: {4}", ships[i].getname(), ships[i].gethit_points, ships[i].getspeed(), ships[i].getdamage(), ships[i].getfriendly());

            }
            else { Console.WriteLine("no ships found"); }
        }   
    }
}

class Space_Object
{
    private string name;
    private int hit_points;
    public Space_Object(string myname, int myhp)
    {
        name = myname;
        hit_points = myhp;
    }
    public void setname(string newname)
    {
        name = newname;
    }
    public void sethit_points(int newhp)
    {
        hit_points = newhp;
    }

    public string getname()
    {
        return name;
    }

    public int gethit_points()
    {
        return hit_points;
    }

}
class Alien_ship : Space_Object
{
    private int speed;
    private int damage;
    private bool friendly;
    public Alien_ship(string myname, int myhp,int spd, int mydmg, bool frnd) : base(myname, myhp)
    {
        speed = spd;
        damage = mydmg;
        friendly = frnd;
    }
    
    public int getspeed()
    { 
        return speed;
    }
    public void setspeed(int newspeed)
    {
        speed = newspeed;
    }
    public void setdamage(int newdmg)
    {
        damage = newdmg;
    }
    public int getdamage()
    {
        return damage;
    }
    public void setfriendly(bool newfrnd)
    {
        friendly = newfrnd;
    }
    public bool getfriendly()
    {
        return friendly;
    }
}