using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Matrix
{
    private double[,] M;
    public Matrix(double[,] m)
    {
        M = m;
    }
    public int Rows
    {
        get{ return M.GetLength(0);}
    }
    public int Cols => M.GetLength(1);

    public override string ToString()
    {
        var s = "{\r\n";
        for (var i=0; i<Rows; i++)
        {
            s+=" { ";
            for(var j=0; j<Cols; j++)
                s+= $"{M[i, j]}, ";
            
            s+= "},\r\n";
            
        } 

        s+= "}";
        return s;
    }
    public static Matrix Transpons(Matrix A)
    {
        var b = new double[A.Rows, A.Cols];
        for (var i=0; i<A.Rows; i++)
           for (var j=0; j<A.Cols; j++)
           b[j,i] = A.M[i,j];
        return new Matrix(b);
    }

  
    public Matrix GetTransposed()
    {
        var b = new double[Rows, Cols];
        for (var i=0; i<Rows; i++)
           for (var j=0; j<Cols; j++)
           b[j,i]= M[i,j]; 
        return new Matrix(b);
    }
    public static Matrix operator +(Matrix A, Matrix B)
    {
        var c = new double[A.Rows, A.Cols];
        for (var i=0; i<A.Rows; i++)
          for (var j=0; j<A.Cols; j++)
          c[i,j]= A.M[i,j]+ B.M[j,i];
          return new Matrix(c);
    }
      public static Matrix operator -(Matrix A, Matrix B)
    {
        var c = new double[A.Rows, A.Cols];
        for (var i=0; i<A.Rows; i++)
          for (var j=0; j<A.Cols; j++)
          c[i,j]= A.M[i,j]- B.M[j,i];
          return new Matrix(c);
    }
      public static Matrix operator +(Matrix A, double B)
    {
        var c = new double[A.Rows, A.Cols];
        for (var i=0; i<A.Rows; i++)
          for (var j=0; j<A.Cols; j++)
          c[i,j]= A.M[i,j]+ B;
          return new Matrix(c);
    }
       public static Matrix operator -(Matrix A, double B)
    {
        var c = new double[A.Rows, A.Cols];
        for (var i=0; i<A.Rows; i++)
          for (var j=0; j<A.Cols; j++)
          c[i,j]= A.M[i,j]- B;
          return new Matrix(c);
    }
      public static Matrix operator +(double A, Matrix B)
    {
        var c = new double[B.Rows, B.Cols];
        for (var i=0; i<B.Rows; i++)
          for (var j=0; j<B.Cols; j++)
          c[i,j]= A + B.M[j,i];
          return new Matrix(c);
    }
      public static Matrix operator -(double A, Matrix B)
    {
        var c = new double[B.Rows, B.Cols];
        for (var i=0; i<B.Rows; i++)
          for (var j=0; j<B.Cols; j++)
          c[i,j]= A - B.M[j,i];
          return new Matrix(c);
    }

       public static Matrix operator *(Matrix A, Matrix B)
    {
        var c = new double[A.Rows, B.Cols];
        for (var i=0; i<A.Rows; i++)
          for (var j=0; j<B.Cols; j++)
            for (int k = 0; k < B.Rows; k++)              
              c[i,j]+= A.M[i,k] * B.M[k,j];
          return new Matrix(c);
    }
      public static Matrix operator *(double A, Matrix B)
    {
        var c = new double[B.Rows, B.Cols];
        for (var i=0; i<B.Rows; i++)
          for (var j=0; j<B.Cols; j++)
           c[i,j]= A * B.M[i,j];
          return new Matrix(c);
    }
       public static Matrix operator *(Matrix A, double B)
    {
        var c = new double[A.Rows, A.Cols];
        for (var i=0; i<A.Rows; i++)
          for (var j=0; j<A.Cols; j++)
           c[i,j]= B * A.M[i,j];
          return new Matrix(c);
    }
       public static Matrix det(Matrix A, Matrix B)
      { 
        double det = 1;
        const double EPS = 1E-9;
        int n;
        n = B.Cols;
        double[][] a = new double[n][];
        double[][] b = new double[1][];
        b[0] = new double[n];

        for (var i=0; i<B.Rows; i++)
          { int k=i;
            for (var j=i+1; j<B.Rows; j++)
            if (Math.Abs(B.M[j,i]) > Math.Abs(B.M[k,i]))
              k = j;
            if (Math.Abs(B.M[k,i]) < EPS)
              {
                det = 0;
                break;
              }

              b[0] = a[i];
              a[i] = a[k];
              a[k] = b[0];
              
              if (i != k)
              det = -det;
              det *= a[i][i];
               
              for (int j=i+1; j<n; ++j)
                  a[i][j] /= a[i][i];
                for (int j=0; j<n; ++j)
                
                    if ((j != i)&&(Math.Abs(a[j][i]) > EPS))
                        for (k = i+1; k < n; ++k)
                            a[j][k] -= a[i][k] * a[j][i];
                            
                            
          }
       return (det);
                             
       }
       
}
