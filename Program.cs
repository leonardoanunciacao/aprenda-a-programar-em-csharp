// See https://aka.ms/new-console-template for more information
using System.ComponentModel;

string mensagemDeBoasVindas = "Bem vindo ao Screen Sound";
//List<string> listaDasBandas = new List<string>{"U2", "The Beatles", "The Killers"};

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Pink Floyd", [10, 9, 10, 8]);
bandasRegistradas.Add("The Bealtes", []);

void ExibirLogo() {
    Console.WriteLine(@"
╭━━━╮╱╱╱╱╱╱╱╱╱╱╱╱╱╱╭━━━╮╱╱╱╱╱╱╱╱╱╱╭╮
┃╭━╮┃╱╱╱╱╱╱╱╱╱╱╱╱╱╱┃╭━╮┃╱╱╱╱╱╱╱╱╱╱┃┃
┃╰━━┳━━┳━┳━━┳━━┳━╮╱┃╰━━┳━━┳╮╭┳━╮╭━╯┃
╰━━╮┃╭━┫╭┫┃━┫┃━┫╭╮╮╰━━╮┃╭╮┃┃┃┃╭╮┫╭╮┃
┃╰━╯┃╰━┫┃┃┃━┫┃━┫┃┃┃┃╰━╯┃╰╯┃╰╯┃┃┃┃╰╯┃
╰━━━┻━━┻╯╰━━┻━━┻╯╰╯╰━━━┻━━┻━━┻╯╰┻━━╯
    ");
    Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirOpcoesDoMenu(){
    ExibirLogo();
    Console.WriteLine("Digite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a media de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);
    switch (opcaoEscolhidaNumerica){
        case 1: RegistrarBandas();
            break;
        case 2: ExibirListaDasBandas();
            break;
        case 3: AvaliarUmaBanda();
            break;
        case 4: Console.WriteLine($"Voce escolheu a opcao {opcaoEscolhidaNumerica}");
            break;
        case -1: Console.WriteLine($"Voce escolheu a opcao {opcaoEscolhidaNumerica}. Saindo...");
            break;
        default: Console.WriteLine("Opção inválida");
            break;
    }
}

void RegistrarBandas(){
    Console.Clear();
    ExibirTituloDaOpcao("Registrar Bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    bool bandaEncontrada = VerificarBandaRegistrada(nomeDaBanda);
    
    if(!bandaEncontrada){
        bandasRegistradas.Add(nomeDaBanda, []);
        Thread.Sleep(1000);
        Console.Write("Salvando.");
        Thread.Sleep(1000);
        Console.Write(".");
        Thread.Sleep(1000);
        Console.Write(".");
        Thread.Sleep(1000);
        Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
        Thread.Sleep(3000);
    } else {
        Console.WriteLine($"Banda {nomeDaBanda} já registra.");
        Thread.Sleep(3000);
    }
    Console.Clear();
    ExibirOpcoesDoMenu();

}

void ExibirListaDasBandas(){
    Console.Clear();
    ExibirTituloDaOpcao("Bandas Registradas");
    foreach(string element in bandasRegistradas.Keys){
        Console.WriteLine(element);
    }
    Console.WriteLine("Pressione uma tecla para voltar ao menu principal.");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine($"{asteriscos}\n");
}

bool VerificarBandaRegistrada(string nomeDaBanda){
    bool bandaEncontrada = false;
    // foreach(string item in bandasRegistradas.Keys)
    // {
    //     if(nomeDaBanda == item){
    //         bandaEncontrada = true;
    //     }
    // }

    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        bandaEncontrada = true;
    }

    return bandaEncontrada;
}

void AvaliarUmaBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Avaliar uma banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    bool bandaEncontrada = VerificarBandaRegistrada(nomeDaBanda);
    
    if(bandaEncontrada){
        Console.Write($"Dê a sua nota para {nomeDaBanda}: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"Nota {nota} atribuída a banda {nomeDaBanda}");
    } else {
        Console.WriteLine($"\nBanda {nomeDaBanda} não registrada.");
    }
    Console.Clear();
    ExibirOpcoesDoMenu();

}

ExibirOpcoesDoMenu();