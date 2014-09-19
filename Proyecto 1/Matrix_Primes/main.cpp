#include <cstdlib>
#include <iostream>
#include <time.h>
#include <pthread.h>
#include <unistd.h>





#include <mutex>

using namespace std;

/**********************************************************************************************************************************
 **********************************************************************************************************************************
*/

int** matrixA;
int** matrixB;
int** matrixC;
int x[2];
int y[2];

/**********************************************************************************************************************************
 **********************************************************************************************************************************
*/

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
               //num = rand() % 100 + 1;
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

/* Description: Multiplicación de matrices
 * Params: -
 * Return: -
 */
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
		     cout<< temp << " ";
	 	 }
	     cout<<"\n";
	 }
     end = clock();
     cout<<"\n\n";
     cout<< (double)(end-start)/CLOCKS_PER_SEC << " seconds." << "\n\n";
     cout<<"\n\n\n\n";

     destroyMatrix(true);
     destroyMatrix(false);
     
     system("PAUSE");
}

/* Description: Multiplicación de matrices concurrente
 * Params: -
 * Return: -
 */
 
int size;
int n=0;
bool get1;
bool get2;
//std::mutex foo,bar;

void *multAux1(void * arg) {
	/*lock (foo,bar);
  	cout << "task a\n";
  	foo.unlock();
  	bar.unlock();*/
	
	
	
	/*while(true) {
		while(get2) {
			cout << "hilo 1\n";
		}
		if(get1) {
			if(n < x[0]) {
				for(int j=0; j < y[1]; j++) {
					int temp = 0;
					for(int k = 0; k < size; k++) {
						temp += matrixA[n][k] * matrixB[k][j];
					}	
					matrixC[n][j] = temp;
					cout<< temp << " ";
				}
				cout<<" h1\n";
				n++;
			} else {
				return 0;
			}
			get1 = false;
			get2 = true;
		}
	}*/
}

void *multAux2(void * arg) {
	/*lock (bar,foo);
  	cout << "task b\n";
  	bar.unlock();
  	foo.unlock();*/
	
	/*while(true) {
		while(get1) {
			cout << "hilo 2\n";
		}
		if(get2) {
			if(n < x[0]) {
				for(int j=0; j < y[1]; j++) {
					int temp = 0;
					for(int k = 0; k < size; k++) {
						temp += matrixA[n][k] * matrixB[k][j];
					}	
					matrixC[n][j] = temp;
					cout<< temp << " ";
				}
				cout<<" h2\n";
				n++;
			} else {
				return 0;
			}
			get2 = false;
			get1 = true;
		}
	}*/
}

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

bool primeNumber(int num) {
	for(int i=2; i < num; i++) {
		if(num % i == 0) {
			return false;	
		}
	}
	return true;
}

/* Description: Factorizacion de Numeros por el Metodo de los Primos
 * Params: -
 * Return: -
 */
void factNumbers() {
     string in;
     int number;
	 
	 system("CLS");
	 cout<<"Numero a Factorizar: ";
	 getline(cin, in);
	 
	 number = atoi(in.c_str());
	 
	 for(int i=2; i < 998; i++) {
	 	if(primeNumber(i)) {
	 		if(number % i == 0) {
				cout << i << " * ";
				number /= i;
				i=2;
	 		}
	 		if(primeNumber(number)) {
	 			cout << number << " \n";
				system("PAUSE");
	 			return;
	 		}
	 	}
	 } 
}

/* Description: Factorizacion de Numeros por el Metodo de los Primos
 * Params: -
 * Return: -
 */
void factNumbersConcurrent() {
     
}

/**********************************************************************************************************************************
 **********************************************************************************************************************************
*/

int main(int argc, char *argv[]) {
	cout << Environment::ProcessorCount << "\n\n\n";
/*
pthread_t t1;

    pthread_create(&t1, NULL, &print_message, NULL);
    cout << "Hello";*/

	
	
	
	
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
			 factNumbers();
             break;
        case 4 :
             
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
