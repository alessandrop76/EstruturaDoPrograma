using System;

namespace Revisao2
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[15];
            var indiceAluno = 0;
            decimal mediaGeral;
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno:");
                        var aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Infome a nota do Aluno:");
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("Valor da nota deve ser numero");
                        }
                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                        break;

                    case "2":
                        foreach (var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"ALUNO: {a.Nome} - NOTA: {a.Nota}");
                            }
                        }
                        break;

                    case "3":
                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        for (int i = 0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }

                        }

                        mediaGeral = notaTotal / nrAlunos;
                        //mediaGeral = mediaGeral;
                        ConceitoEnum conceito = 0;

                        if (mediaGeral <= 2)
                        {
                           conceito = ConceitoEnum.E;

                        }
                        if (mediaGeral > 2 && mediaGeral <= 4)
                        {
                            conceito = ConceitoEnum.D;
                        }
                        if (mediaGeral > 4 && mediaGeral <= 6)
                        {
                            conceito = ConceitoEnum.C;
                        }
                        if (mediaGeral > 6 && mediaGeral <= 8)
                        {
                            conceito = ConceitoEnum.B;
                        }
                        if(mediaGeral > 8 && mediaGeral <= 9)
                        {
                            conceito = ConceitoEnum.B2;
                        }
                         else if(mediaGeral > 9)
                        {
                            conceito = ConceitoEnum.A;
                        }

                        //   if(mediaGeral < 2)
                        //    {
                        //        mediaGeral = ConceitoEnum.E;
                        //    }
                        //    if(mediaGeral < 4)
                        //    {
                        //        mediaGeral = ConceitoEnum.D;
                        //    }
                        //    if(mediaGeral < 6)
                        //    {
                        //        mediaGeral = ConceitoEnum.C;
                        //    }
                        //    if(mediaGeral < 8)
                        //    {
                        //        mediaGeral = ConceitoEnum.B;
                        //    }
                        //    else
                        //    {
                        //        mediaGeral = ConceitoEnum.A;
                        //    }

                        Console.WriteLine("A nota média geral é: " + notaTotal / nrAlunos);
                        Console.WriteLine("E o Conceito da turma é: " + conceito);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada");
            Console.WriteLine("1 - Insira um novo Aluno:");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Exibir Média do Curso:");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}