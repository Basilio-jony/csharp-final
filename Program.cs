using System;
using System.Collections.Generic;//usamos para trabalhar com listas de objectos como a lista <professor>

public class Disciplina
{
    public string NomeCadeira;
    public Professor Professor;

    public Disciplina(string nomeCadeira, Professor professor)
    {
        NomeCadeira = nomeCadeira;
        Professor = professor;
    }
}

public class Professor
{
    public string Nome;
    public int Idade;
    public string Genero;
    public float Salario;

    public Professor(string nome, int idade, string genero, float salario)
    {
        Nome = nome;
        Idade = idade;
        Genero = genero;
        Salario = salario;
    }
}

class Program
{
    static void Main(string[] argc)
    {
        List<Professor> professores = new List<Professor>
        {
            new Professor("João Silva", 30, "M", 50000),
            new Professor("Maria Oliveira", 25, "F", 40000),
            new Professor("Pedro Santos", 35, "M", 60000),
            new Professor("Ana Costa", 25, "F", 70000)
        };
        //criar disciplinas e associando professores
        List<Disciplina> disciplinas = new List<Disciplina>
        {
            new Disciplina("Matemática", professores[1]), //Maria oliveira
            new Disciplina("História", professores[0]), //Joao silva
            new Disciplina("Física", professores[3]), //Ana costa
            new Disciplina("Informática", professores[2]) //Pedro santos
        };

        Professor profMaiorSal = professores[0];
        Professor profMaisjovem = professores[0];
        //encontrar o professor com maior salário e o mais jovem
        foreach (var professor in professores)
        { //para cada professor na lista, duas condiçoes são verificadas: maior salário e mais jovem
            if (professor.Salario > profMaiorSal.Salario)//se o salario do professor atual(professor.salario) for maior que o salario do professor armazenado em "profMaiorSal", entao "profMaiorSal" é atualizado para ser o professor atual.
            {
                profMaiorSal = professor;
            }
            if (professor.Idade < profMaisjovem.Idade)//mais jovem segue a mesma premissa do prof com maior salario
            {
                profMaisjovem = professor;
            }
        }
        //listas para armazenar professores por gênero
        List<Professor> profsFemeninos = new List<Professor>();
        List<Professor> profsMasculinos = new List<Professor>();
        //separar professores por gênero
        foreach (var professor in professores)
        {
            if (professor.Genero == "F")
            {
                profsFemeninos.Add(professor);
            }//se o genero do professor for feminino, ele é adicionado a lista de professores femininos
            else if (professor.Genero == "M")
            {
                profsMasculinos.Add(professor);
            }//mesma coisa
        }
        //imprime os resultados
        Console.WriteLine($"professor com o maior salário: {profMaiorSal.Nome}, Salario: {profMaiorSal.Salario}");
        Console.WriteLine($"professor mais jovem: {profMaisjovem.Nome}, Idade: {profMaisjovem.Idade}");
        //imprime as listas por generos
        Console.WriteLine("\nProfessores do genero Feminino:");
        foreach (var prof in profsFemeninos)
        {
            Console.WriteLine($"Nome: {prof.Nome}, Idade: {prof.Idade}, Salario: {prof.Salario}");
        }

        Console.WriteLine("\nProfessores do genero masculino:");
        foreach (var prof in profsMasculinos)
        {
            Console.WriteLine($"Nome: {prof.Nome}, Idade: {prof.Idade}, Salario: {prof.Salario}");
        }
        //imprime as disciplinas e seus profs
        Console.WriteLine("\nDisciplinas e seus professores:");
        for (int i = 0; i < disciplinas.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {disciplinas[i].NomeCadeira} - {disciplinas[i].Professor.Nome}");
        }
        //finalmente acabou :) 
        Console.WriteLine("Pressione qualquer tecla para sair...");
        Console.ReadKey(); //essa funcao espera o usuario pressionar uma tecla
    }
}