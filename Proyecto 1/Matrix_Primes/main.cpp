#include <cstdlib>
#include <iostream>
#include <time.h>
#include <pthread.h>
#include <unistd.h>

using namespace std;

/**********************************************************************************************************************************
 **********************************************************************************************************************************
*/

// variables globales
int** matrixA;
int** matrixB;
int** matrixC;
int x[2];
int y[2];
bool cores = true;

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
 
int size;
int n=0;
bool get1;
bool get2;

// Primer proceso de ejecucion de multiplicacion de matrices paralelo
void *multAux1(void * arg) {
	while(true) {
		while(get2) { }
		if(get1) {
			if(n < x[0]) {
				for(int j=0; j < y[1]; j++) {
					int temp = 0;
					for(int k = 0; k < size; k++) {
						temp += matrixA[n][k] * matrixB[k][j];
					}	
					matrixC[n][j] = temp;
				}
				n++;
			} else {
				return 0;
			}
			get1 = false;
			get2 = true;
		}
	}
}

// Segundo proceso de ejecucion de multiplicacion de matrices paralelo
void *multAux2(void * arg) {
	while(true) {
		while(get1) { }
		if(get2) {
			if(n < x[0]) {
				for(int j=0; j < y[1]; j++) {
					int temp = 0;
					for(int k = 0; k < size; k++) {
						temp += matrixA[n][k] * matrixB[k][j];
					}	
					matrixC[n][j] = temp;
				}
				n++;
			} else {
				return 0;
			}
			get2 = false;
			get1 = true;
		}
	}
}

// Multiplicación de matrices concurrente
void multMatrixConcurrent() {
     bool error = true;
     int num;
     int i=0;
     int j=0;
     clock_t start, end;

     do {
         system("CLS");
         matrixDimension(true);
         matrixDimension(false);

         if(y[0] == x[1]) {
             error = false;
			 size = y[0]; 
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
	
	cout << "\n matrixA \n\n";
	for(int i=0; i < x[0]; i++) {
		for(int j=0; j < y[0]; j++) {
			cout << " " << matrixA[i][j] << " ";
		}
		cout << "\n";
	}
	
	cout << "\n matrixB \n\n";
	
	for(int i=0; i < x[1]; i++) {
		for(int j=0; j < y[1]; j++) {
			cout << " " << matrixB[i][j] << " ";
		}
		cout << "\n";
	}
	
	cout << "\n matrixC \n\n";
	
     start = clock();

	 get1 = true;
	 get2 = false;
	 pthread_t t1, t2;
	 pthread_create(&t1, NULL, multAux1, NULL);
     pthread_create(&t2, NULL, multAux2, NULL);
	 
     end = clock();
     
     pthread_cancel(t1);
     pthread_cancel(t2);
     
	 cout<<"\n\n";
     cout<< (double)(end-start)/CLOCKS_PER_SEC << " seconds." << "\n\n";
     cout<<"\n\n";

     destroyMatrix(true);
     destroyMatrix(false);
     
     system("PAUSE");
}

/**********************************************************************************************************************************
 **********************************************************************************************************************************
*/

// Valida si un numero es primo o no
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
	 	
	 	if(cores) {
	 		cores = false;
	 		//pthread_create(&t1, 0, factNumberConcurrent, arg1);
	 		//pthread_create(&t2, NULL, factNumberConcurrent, arg2);
	 	} else {
	 		factNumberConcurrent(x);
	 		factNumberConcurrent(y);
	 	}	
	 }
}

 // Factorizacion de Numeros por el Metodo de los Primos
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

// Menu de logaritmos
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
