// See https://aka.ms/new-console-template for more information

string mensagemDeBoasVindas = "Bem vindo ao Screen Sound";

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Pink Floyd", [10, 9, 10, 8]);
bandasRegistradas.Add("The Beatles", [10, 8, 9, 7, 10, 8, 8]);

void ExibirOpcoesDoMenu(){
    Console.Clear();
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
        case 4: ExibirMediaDeUmaBanda();
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
        Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
    } else {
        Console.WriteLine($"Banda {nomeDaBanda} já registra.");
    }
    RetornarAoMenuPrincipal();

}

void ExibirListaDasBandas(){
    ExibirTituloDaOpcao("Bandas Registradas");
    foreach(string element in bandasRegistradas.Keys){
        Console.WriteLine(element);
    }
    RetornarAoMenuPrincipal();
}

void AvaliarUmaBanda()
{
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
    RetornarAoMenuPrincipal();
}

void ExibirMediaDeUmaBanda()
{
    ExibirTituloDaOpcao("Exibir avaliacao média de uma banda");

    Console.Write("Digite o nome da banda que deseja ver a avaliação média: ");
    string nomeDaBanda = Console.ReadLine()!;
    bool bandaEncontrada = VerificarBandaRegistrada(nomeDaBanda);
    
    if (bandaEncontrada)
    {
        List<int> notasDaBanda = bandasRegistradas[nomeDaBanda];
        Console.WriteLine($"A avaliação média da banda {nomeDaBanda} é {notasDaBanda.Average()}.");
    } else {
        Console.WriteLine($"Banda {nomeDaBanda} não registrada");
    }
    RetornarAoMenuPrincipal();
}

bool VerificarBandaRegistrada(string nomeDaBanda){
    bool bandaEncontrada = false;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        bandaEncontrada = true;
    }

    return bandaEncontrada;
}

void RetornarAoMenuPrincipal()
{
    Console.WriteLine("Pressione uma tecla para voltar ao menu principal.");
    Console.ReadKey();
    ExibirOpcoesDoMenu();
}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.Clear();
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine($"{asteriscos}\n");
}

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

ExibirOpcoesDoMenu();