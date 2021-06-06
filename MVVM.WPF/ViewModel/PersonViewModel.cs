using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using MVVM.WPF.Model;
using MVVM.WPF.Model.Persistence;
using MVVM.WPF.Model.Repository;

namespace MVVM.WPF.ViewModel
{
    public class PersonViewModel : BaseViewModel
    {
        //private DataRepository _data = new DataRepository();
        private PersonRepository _data;
        private WPFContext db;

        public ObservableCollection<Person> Persons { get; set; }



        public ICommand SalvarCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand LoadCommand { get; set; }


        public PersonViewModel()
        {

            db = new WPFContext();
            _data = new PersonRepository(db);
            this.Persons = new ObservableCollection<Person>();

            this.SelectedPerson = new Person();
            this.SalvarCommand = new ActionCommand(p => Save(), p => IsValid);
            this.EditCommand = new ActionCommand(p => Edit());
            this.DeleteCommand = new ActionCommand(p => Delete());
            this.LoadCommand = new ActionCommand(p => LoadData());

            LoadData();
        }

        public bool IsValid
        {
            get
            {
                bool idade = false;
                bool cep = false;
                bool cpf = false;

                //--Valida SE Nulos
                bool obrigatorios = !string.IsNullOrWhiteSpace(CEP) &&
                                     !string.IsNullOrWhiteSpace(Estado) &&
                                     !string.IsNullOrWhiteSpace(Cidade) &&
                                     !string.IsNullOrWhiteSpace(Bairro) &&
                                     !string.IsNullOrWhiteSpace(Numero) &&
                                     !string.IsNullOrWhiteSpace(Logradouro) &&
                                     !string.IsNullOrWhiteSpace(Cpf) &&
                                     !string.IsNullOrWhiteSpace(Nome) &&
                                     !string.IsNullOrWhiteSpace(Sobrenome);


                // Valida Se maior que 18
                if (DataNascimento < DateTime.Now)
                {
                    var i = DateTime.Now.Year - DataNascimento.Year; // 2021 - 2003 = 18 //03 <= 04
                    if (DateTime.Now.DayOfYear > DataNascimento.DayOfYear)
                    {
                        i--;                        
                    }
                    if (i > 17)
                    {
                        idade = true;
                    }
                }

                //--valida quantidade CEP e CPF
                if (!String.IsNullOrWhiteSpace(CEP) && !String.IsNullOrWhiteSpace(Cpf))
                {
                    cep = CEP.Length == 8;
                    cpf = Cpf.Length == 11;
                }                
                return obrigatorios && cep && cpf && idade;
            }
        }


        //-- ACTIONS
        private void Save()
        {
            try
            {
                Person person = new Person()
                {
                    Cpf = Cpf,
                    DataNascimento = DataNascimento,
                    Genero = Genero,
                    Nome = Nome,
                    Sobrenome = Sobrenome,
                    Endereco = new Address
                    {
                        Bairro = Bairro,
                        CEP = CEP,
                        Cidade = Cidade,
                        Estado = Estado,
                        Numero = Numero,
                        Complemento = Complemento,
                        Logradouro = Logradouro
                    }
                };

                _data.Create(person);

                this.Persons.Add(person);

            }
            catch (Exception)
            {

                throw;
            }
          
        }

        private void Edit()
        {

            try
            {
                Person person = SelectedPerson;
                _data.Update(person);

                SelectedPerson = null;
                LoadData();
            }
            catch (Exception)
            {

                throw;
            }
            

        }

        private void Delete()
        {
            try
            {
                _data.Delete(SelectedPerson.Id);
                LoadData();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private void LoadData()
        {
            Persons.Clear();
            var persons = _data.GetAll();
            foreach (Person person in persons)
            {
                this.Persons.Add(person);
            }
        }


        


        //--PROPERTIES

        private Person selectedPerson;
        public Person SelectedPerson
        {
            get
            {
                return selectedPerson;
            }
            set
            {
                selectedPerson = value;
                NotifyProperty("SelectedPerson");
            }
        }

        private string id;
        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                NotifyProperty("Id");
            }
        }

        private string nome;
        public string Nome
        {
            get
            {
                return nome;
            }
            set
            {
                nome = value;
                NotifyProperty("Nome");
            }
        }


        private string sobrenome;
        public string Sobrenome
        {
            get
            {
                return sobrenome;
            }
            set
            {
                sobrenome = value;
                NotifyProperty("Sobrenome");
            }
        }


        private string cpf;
        public string Cpf
        {
            get
            {
                return cpf;
            }
            set
            {
                cpf = value;
                NotifyProperty("Cpf");
            }
        }


        private DateTime dataNascimento;
        public DateTime DataNascimento
        {
            get
            {
                return dataNascimento;
            }
            set
            {
                dataNascimento = value;
                NotifyProperty("DataNascimento");
            }
        }


        private string genero;
        public string Genero
        {
            get
            {
                return genero;
            }
            set
            {
                genero = value;
                NotifyProperty("DataNascimento");
            }
        }

        private string logradouro;
        public string Logradouro
        {
            get
            {
                return logradouro;
            }
            set
            {
                logradouro = value;
                NotifyProperty("Logradouro");
            }
        }

        private string numero;
        public string Numero
        {
            get
            {
                return numero;
            }
            set
            {
                numero = value;
                NotifyProperty("Numero");
            }
        }

        private string bairro;
        public string Bairro
        {
            get
            {
                return bairro;
            }
            set
            {
                bairro = value;
                NotifyProperty("Bairro");
            }
        }

        private string cidade;
        public string Cidade
        {
            get
            {
                return cidade;
            }
            set
            {
                cidade = value;
                NotifyProperty("Cidade");
            }
        }

        private string estado;
        public string Estado
        {
            get
            {
                return estado;
            }
            set
            {
                estado = value;
                NotifyProperty("Estado");
            }
        }


        private string complemento;
        public string Complemento
        {
            get
            {
                return complemento;
            }
            set
            {
                complemento = value;
                NotifyProperty("Complemento");
            }
        }

        private string cep;
        public string CEP
        {
            get
            {
                return cep;
            }
            set
            {
                cep = value;
                NotifyProperty("CEP");
            }
        }
    }
}
