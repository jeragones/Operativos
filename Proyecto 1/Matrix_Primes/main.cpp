#include <cstdlib>
#include <iostream>
#include <time.h>
#include <pthread.h>
#include <unistd.h>
#define size 400

using namespace std;

/**********************************************************************************************************************************
 **********************************************************************************************************************************
*/

// variables globales
int** matrixA;
int** matrixB;
int** matrixC;
int row1, vect, col2;
int matrizA[size][size]; 
int matrizB[size][size];
int matrizC[size][size];
int x[2];
int y[2];
bool cores = false;

/**********************************************************************************************************************************
 **********************************************************************************************************************************
*/

// Funcion para llenar la matriz de valores aleatorios del 1 al 10
// tmp: indica si es la matriz A o la matriz B
void makeMatrix(bool tmp) {
     int num, f, c;
     if(tmp) {
     	  f = x[0];
     	  c = y[0];
     } else {
     	  f = x[1];
     	  c = y[1];
     }
     for(int i=0; i < f; i++) {
          for(int j=0; j < c; j++) {
               num = rand() % 10;
               if(tmp) {
                    matrixA[i][j] = num;
               } else {
               		matrixB[i][j] = num;
               }
          }
     }
}

/**********************************************************************************************************************************
 **********************************************************************************************************************************
*/

// Libera el espacio en memoria que esta ocupando la matriz
// tmp: indica si es la matriz A o la matriz B
void destroyMatrix(bool tmp) {
	int f, c;
	
	if(tmp) {
		f = x[0];
	} else {
		f = x[1];
	}
	
	for(int i=0; i < f; i++) {
		if(tmp) {
			delete[] matrixA[i];
		} 
	}
	
	if(tmp) {
		delete[] matrixA;	
	} else {
		delete[] matrixB;
	}
}

/**********************************************************************************************************************************
 **********************************************************************************************************************************
*/

// Define las dimensiones que va a tener la matriz
// tmp: indica si es la matriz A o la matriz B
void matrixDimension(bool tmp) {
    string rows, cols;
    bool menu = true;
    
    if(tmp) {
    	cout<<"\n***** Dimension de la Primera Matriz *****\n\n\n";
    } else {
    	cout<<"\n***** Dimension de la Segunda Matriz *****\n\n\n";
    }
    
    do {
        cout<<"Filas: ";
        getline(cin, rows);    
        if(atoi(rows.c_str()) > 0) {
            menu = false;
        } else {
            cout<<"ERROR: EL TAMANIO DE LAS FILAS DEBE SER MAYOR A CERO.";
        }
    } while(menu);
    
    menu = true;
    
	do {
        cout<<"Columnas: ";
        getline(cin, cols);
        if(atoi(cols.c_str()) > 0) {
            menu = false;
        } else {
            cout<<"ERROR: EL TAMANIO DE LAS COLUMNAS DEBE SER MAYOR A CERO.";
        }
    } while(menu);
    
    if(tmp) {
    	x[0] = atoi(rows.c_str());
    	y[0] = atoi(cols.c_str());
    	matrixA = new int*[x[0]];
    	
    	for(int i=0; i < x[0]; i++) {
    		matrixA[i] = new int[y[0]];	
    	}
    } else {
    	x[1] = atoi(rows.c_str());
    	y[1] = atoi(cols.c_str());
		matrixB = new int*[x[1]];
		
    	for(int i=0; i < x[1]; i++) {
    		matrixB[i] = new int[y[1]];	
    	}
    }
}

/**********************************************************************************************************************************
 **********************************************************************************************************************************
*/

// Multiplicación de matrices de forma secuencial
void multMatrix() {
     bool error = true;
     int num, z;
     clock_t start, end;
     
     do {
         system("CLS");
         matrixDimension(true);
         matrixDimension(false);

         if(y[0] == x[1]) {
             error = false;
			 z = y[0]; 
         } else {
              cout<<"ERROR: LAS MATRICES NO SON CONFORMABLES.\n\n";
              system("PAUSE");
         }
     } while(error);
     
     matrixC = new int*[x[0]];	
	 for(int i=0; i < x[0]; i++) {
	 	matrixC[i] = new int[y[1]];	
	 }
     
     makeMatrix(true);
     makeMatrix(false);

     system("CLS");

     start = clock();
	 for (int i = 0; i < x[0]; i++) {
	     for (int j = 0; j < y[1]; j++) {
	         int temp = 0;
	     	 for (int k = 0; k < z; k++) {
	             temp += matrixA[i][k] * matrixB[k][j];
	     	 }
		     matrixC[i][j] = temp;
	 	 }
	 }
     end = clock();
     cout<<"\n\n";
     cout<< (double)(end-start)/CLOCKS_PER_SEC << " seconds." << "\n\n";
     cout<<"\n\n\n\n";

     destroyMatrix(true);
     destroyMatrix(false);
     
     system("PAUSE");
}

/**********************************************************************************************************************************
 **********************************************************************************************************************************
*/

// Funcion que se encarga de realizar la multiplicacion entre las matrices A,B
// dim: dimension de la matriz 
void *parallelMult(void *dim) {
	int row;
	int col;
	int result=0;
	int *dimension;
	
	dimension = (int *) dim;
	row = dimension[0];
	col = dimension[1];
	
	for(int i=0; i<vect; i++) {
		result += matrizA[row][i] * matrizB[i][col];
		//printf("%d * %d\n",matrizA[row][i],matrizB[i][col]);
	}
	//printf("         = %d\n",result);
	
	
	matrizC[row][col] = result;
}

// Funcion que llena las matrices con valores aleatorios del 1 al 9
// mat: matriz que se va a llenar
// row: cantidad de filas de la matriz
// col: cantidad de columnas de la matriz
void fillMatrix(int mat[size][size], int row, int col) {
	int num;
	
	for(int i=0; i<row; i++) {
		for(int j=0; j<col; j++) {
			num = (rand() % 9) + 1;
			mat[i][j] = num;
		}
	}	
}

// Funcion para imprimir los valores de las matrices A, B, C
void printMatrix() {
	printf("\n");
	for(int i=0; i<row1 ;i++) {
		for(int j=0;j<vect;j++) {
			if(i < row1)
			printf(" %d ",matrizA[i][j]);
		}
		
		if(i == vect / 2)
			printf("\t*\t");
		else
			printf("\t\t");
			
		for(int j=0; j<col2; j++) {
			if(i < vect)
			printf(" %d ",matrizB[i][j]);
		}
		
		if(i == row1 / 2)
			printf("\t=\t");
		else
			printf("\t\t");
			
		for(int j=0; j<col2; j++) {
			if(i < row1) {
				printf(" %d ",matrizC[i][j]);
			}
		}
				
		printf("\n");
	}
	
	printf("\n");
}

// Funcion padre para la multiplicación de matrices concurrente
void multMatrixConcurrent() {
    int dimension[2];
	pthread_t m[size][size];
	clock_t start, end;
	system("CLS");
	cout<<"\n***** Dimension de la Primera Matriz *****\n\n\n";
	printf("filas: ");
	scanf("%d",&row1);
	
	
	printf("Columnas: ");
	scanf("%d",&vect);
	printf("\n");
	
	fillMatrix(matrizA, row1, vect);
	
	cout<<"\n***** Dimension de la Segunda Matriz *****\n\n\n";
	printf("Columnas: ");
	scanf("%d",&col2);
	printf("\n");
	
	fillMatrix(matrizB, vect, col2);

	for(int i=0; i<row1; ++i){
		for(int j=0; j<col2; ++j){
        	matrizC[i][j] = 0;
        }
	}
    system("PAUSE");
        
	start = clock();
	for(int i=0; i<row1; i++) {
		for(int j=0; j<col2; j++) {
			dimension[0]= i;
			dimension[1]= j;
			pthread_create(&m[i][j], NULL, parallelMult, dimension);
		}
	}
		
	end = clock();
	
	cout<<"\n\n";
 	cout<< (double)(end-start)/CLOCKS_PER_SEC << " seconds." << "\n\n";
 	cout<<"\n\n\n\n";

	system("PAUSE");
	
	cout<<"\n\n\n Impresion \n\n\n";
	printMatrix();
	
	system("PAUSE");
	
	cout<<endl;
}

/**********************************************************************************************************************************
 **********************************************************************************************************************************
*/

// Valida si un numero es primo o no
// num: numero que se quiere comprobar si es primo o no
bool primeNumber(int num) {
	for(int i=2; i < num; i++) {
		if(num % i == 0) {
			return false;	
		}
	}
	return true;
}

// Factorizacion de Numeros secuencial por el Metodo de los Primos
// number: numero que se va a factorizar
void factNumberSequential(int number) {
     bool flag=true;
	 int x=1;
	 int y=1;
	 int mult;
	 if(primeNumber(number)) {
	 	cout <<" \n"<<number;
	 	return;
	 } else {
		while(true) {
			if(flag) {
				x++;
				flag = false;
			} else {
				y++;
			}
			mult = x * y;
			if(mult == number) {
				break;
			} else if(mult > number) {
				if(flag) {
					x--;
					flag = false;
				} else {
					y--;
					flag = true;
				}
			} else {
				flag = false;
			}
	 	}
	 	factNumberSequential(x);
		factNumberSequential(y);
	 }
}

pthread_t t1, t2;

// Factorizacion de Numeros paralelo por el Metodo de los Primos
// number: numero que se va a factorizar
void factNumberConcurrent(int number) {
	 bool flag=true;
	 int x=1;
	 int y=1;
	 int mult;

	 if(primeNumber(number)) {
	 	cout <<" \n"<<number;
		 return;
	 } else {
		while(true) {
			if(flag) {
				x++;
				flag = false;
			} else {
				y++;
			}
			mult = x * y;
			if(mult == number) {
				break;
			} else if(mult > number) {
				if(flag) {
					x--;
					flag = false;
				} else {
					y--;
					flag = true;
				}
			} else {
				flag = false;
			}
	 	}
	 	
	 	//if(cores) {
	 	//	cores = false;
	 		//pthread_create(&t1, 0, factNumberConcurrent, arg1);
	 		//pthread_create(&t2, NULL, factNumberConcurrent, arg2);
	 	//} else {
	 		factNumberConcurrent(x);
	 		factNumberConcurrent(y);
	 	//}	
	 }
}

 // Factorizacion de Numeros por el Metodo de los Primos
 // type: indica cual metodo ejecutar si el secuencial o el paralelo
void factNumbers(bool type) {
     string in;
     int number;
     int *arg;
	 clock_t start, end;
	 
	 system("CLS");
	 cout<<"Numero a Factorizar: ";
	 getline(cin, in);
	 
	 number = atoi(in.c_str());
	 
	 if(type) {
	 	start = clock();
	 	factNumberSequential(number);
	 	end = clock();
	 } else {
	 	cores = true;
	 	start = clock();
	 	factNumberConcurrent(number);
	 	end = clock();
	 }
	 
	 cout<<"\n\n";
     cout<< (double)(end-start)/CLOCKS_PER_SEC << " seconds." << "\n\n";
     cout<<"\n\n";
	 
	 system("PAUSE");
}

/**********************************************************************************************************************************
 **********************************************************************************************************************************
*/

// Metodo principal el cual contiene el Menu principal de los logaritmos
int main(int argc, char *argv[]) {
    string op;
    bool menu = true;
    do {
        system("CLS");
        cout<<"\n*************** Menu ***************\n\n\n";
        cout<<"1.Multiplicacion de Matrices\n"; 
        cout<<"2.Multiplicacion de Matrices Concurrente\n";
        cout<<"3.Facturacion de Numeros\n";
        cout<<"4.Facturacion de Numeros Concurrente\n";
        cout<<"5.Salir\n\n";
        cout<<"Opcion: ";
        getline(cin, op);
        switch(atoi(op.c_str())) {
        case 1 :
             multMatrix();
             break;
        case 2 :
			 multMatrixConcurrent();
             break;
        case 3 :
			 factNumbers(true);
             break;
        case 4 :
             factNumbers(false);
             break;
        case 5 :
             menu = false;
             break;
        default :
             cout<<"ERROR: LA OPCION SELECCIONADA NO EXISTE, INTENTE DE NUEVO.\n\n";
             system("PAUSE");
        }
    } while(menu);
    return 0;
}
