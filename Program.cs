

var a = new double [,]
{
    {1,2,3},
    {4,5,6},
    {7,8,9},
};

var A = new Matrix(a);
var b = new double[,]
{
    {9,8,7},
    {6,5,4},
    {3,2,2},   
};

var B = new Matrix(b);
var C = A + B;

Console.WriteLine("Rows:{0}, Cols:{1}", A.Rows, A.Cols);
// Console.WriteLine(A);

// Console.WriteLine(Matrix.Transpons(A));
// Console.WriteLine(A.GetTransposed);

// Console.WriteLine(A+B);
// Console.WriteLine(A.GetTransposed());
Console.WriteLine(A*B);
Console.WriteLine(5*A);

//Console.WriteLine(A/B);
// написать умножение матриц, деление(3 задачи, обратная матр, определитель, прив-е к треугольному виду) : написать свой метод обращения к матрице (проверить умножить матрицу на обратную ей =1 на диагонали)
// обратить матрицу-привести ее к трегольному виду =>определитель