
Console.Write("Enter min x:");
string min_x_str = Console.ReadLine();
Console.Write("Enter max_x:");
string max_x_str = Console.ReadLine();
Console.Write("Enter dx:");
var dx_str = Console.ReadLine();
double min_x = double.Parse(min_x_str);
var max_x = double.Parse(max_x_str);
var dx = double.Parse(dx_str);
        
        
var n = (int)((max_x - min_x) / dx) + 1;
var X = new double[n];


double Polynom(double x)

    {
        return 3 * x * x * x * x
            - 5 * x * x
            + 10 * x
            - 7;
    }

for (int i = 0; i < X.Length; i++)

{
    X[i] = Polynom(min_x + i * dx);
}


double min = double.PositiveInfinity;
int min_i = -1;

for (int i = 0; i < n; i++)
{
    if (X[i] < min)
    {
        min = X[i];
        min_i = i;
    }
}

Console.WriteLine("min(P) = {0} at x ={1}", min, min_i * dx + min_x);


Func<double,double>f = Polynom;
Func<double,double>Sqr(Func<double,double>q)
{
    return x => Math.Pow(q(x), 2);
 
}

void Print(Func<double,double>f, double min_x, double max_x, double dx)
{

    Console.WriteLine("x | F(x)");
    Console.WriteLine("-------");
    double x = min_x;

    while (x < max_x)
    {
        Console.WriteLine("{0} | {1}" , x, f(x));
        x += dx;
    }

}

Print(f, min_x, max_x, dx);
//Print(Sqr(f),3);
