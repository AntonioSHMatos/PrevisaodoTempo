using HttpClientFactory;
using Newtonsoft.Json;
using PrevisaoDoTempo.Modelo;
using PrevisaoDoTempo.Servico.Model;
using System.Net.Http;
using System.Net.Http.Json;
using IHttpClientFactory = System.Net.Http.IHttpClientFactory;

namespace PrevisaoDoTempo.Servico
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly HttpClient _httpClient;


        public Worker(ILogger<Worker> logger, IHttpClientFactory httpClient)
        {
            _logger = logger;
            _httpClient = httpClient.CreateClient();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                PrevisaoDoTempoRetorno previsaodoTempoRetorno = await ObterPrevisaoDoTempo();
                Previsao previsao = ConverterPrevisaoDoTempoRetornoParaPrevisao(previsaodoTempoRetorno);
                await InserirPrevisaoDoTempoInterno(previsao);                                        

                await Task.Delay(46666, stoppingToken);
            }

        }



        private async Task<PrevisaoDoTempoRetorno> ObterPrevisaoDoTempo()
        {
            HttpResponseMessage retorno = await _httpClient.GetAsync($"https://weather.contrateumdev.com.br/api/weather/city/?city=Sao%20Paulo,Sao%20Paulo");
            if (retorno.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<PrevisaoDoTempoRetorno>(await retorno.Content.ReadAsStringAsync());


            }
            else
            {
                throw new Exception(retorno.ReasonPhrase);
            }
        }
        private async Task InserirPrevisaoDoTempoInterno(Previsao previsao)
        {
            HttpResponseMessage retorno = await _httpClient.PostAsJsonAsync($"https://localhost:7050/api/PrevisaoDoTempo", previsao);
            if (retorno.IsSuccessStatusCode)
            {

            }
            else
            {
                throw new Exception(retorno.ReasonPhrase);
            }
        }
        private Previsao ConverterPrevisaoDoTempoRetornoParaPrevisao(PrevisaoDoTempoRetorno previsaoDoTempodoRetorno)
        {
            Previsao previsao = new Previsao();

            previsao.NomeDaCidade = previsaoDoTempodoRetorno.name;

            previsao.TemperaturaMaxima = Convert.ToDecimal(previsaoDoTempodoRetorno.main.temp_max);

            previsao.TemperaturaMinina = Convert.ToDecimal(previsaoDoTempodoRetorno.main.temp_min);

            previsao.Longitude = Convert.ToDecimal(previsaoDoTempodoRetorno.coord.lon);

            previsao.Latitude = Convert.ToDecimal(previsaoDoTempodoRetorno.coord.lat);


            return previsao;
        }

    }
}


