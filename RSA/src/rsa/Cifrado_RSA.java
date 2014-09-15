/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package rsa;

import java.math.BigInteger;
import java.util.Random;

/**
 *
 * @author Daniel
 */
public class Cifrado_RSA {
    
    BigInteger[] publick = new BigInteger[2];
    BigInteger[] privatek = new BigInteger[2];
    
    public void publicKey(String p,String q){
        BigInteger P = new BigInteger(p); 
        BigInteger Q = new BigInteger(q);
        BigInteger N=P.multiply(Q);
        
        BigInteger aux = new BigInteger("1");
        BigInteger Paux1=P.subtract(aux);
        BigInteger Qaux1=Q.subtract(aux);
        BigInteger V=Paux1.multiply(Qaux1);
        
        int pns=V.intValue();
        BigInteger K =new BigInteger("0");
        
        for (int i = 3; i < pns; i++)
        {
            BigInteger x=new BigInteger(Integer.toString(i));
            x=x.gcd(V);
            if (x.intValue()==1)
            {
                K = new BigInteger(Integer.toString(i));
                break;
            }
        }
        publick[0]=K;
        publick[1]=N;
    }
    
    public void privatekey(String p,String q){
        BigInteger P = new BigInteger(p); 
        BigInteger Q = new BigInteger(q);
        BigInteger N=P.multiply(Q);
        BigInteger aux = new BigInteger("1");
        BigInteger Paux1=P.subtract(aux);
        BigInteger Qaux1=Q.subtract(aux);
        BigInteger V=Paux1.multiply(Qaux1);
        
        BigInteger D= null;
        for (int i = 0; i < N.intValue(); i++)
            {
                
                if ((i * publick[0].intValue()) % V.intValue() == 1)
                {
                    D = new BigInteger(Integer.toString(i));
                    break;
                }
            }
        privatek[0]=D;
        privatek[1]=N;
 
    }
    
    public int EncriptarRSA(int m){
        BigInteger E = publick[0];
        BigInteger N = publick[1];
        BigInteger M = new BigInteger(Integer.toString(m));
        BigInteger Maux= M.pow(E.intValue());
        BigInteger Res= Maux.mod(N);
        return Res.intValue();
    }
    
    public int DesencriptarRSA(int m){
        BigInteger D = privatek[0];
        BigInteger N = privatek[1];
        BigInteger M = new BigInteger(Integer.toString(m));
        BigInteger Maux= M.pow(D.intValue());
        BigInteger Res= Maux.mod(N);
        return Res.intValue();
    }
    
}
