using System;

namespace DotNetFiles1{
    public sealed class Cliente{
        public int Id{get;private set;}
        public string Nome{get;private set;}
        public string Endereco{get;private set;}

        public Cliente(int i, string n , string e){
            Validar(i,n,e);
            Id = i;
            Nome = n;
            Endereco=e;
        }
        public void Update(int i, string n , string e){
            Validar(i,n,e);
            Id = i;
            Nome = n;
            Endereco=e;
        }
        private void Validar(int i,string n , string e){
            if(Id<0)
            throw new InvalidOperationException("O Id tem que ser maior do que 0");
            if(n.Length<3)
            throw new InvalidOperationException("O nome deve ter um mínimo de 3 caracteres");
            if(e.Length<5)
            throw new InvalidOperationException("O endereço é inválido");
        }

    }



};