using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KaffeeController : ControllerBase
    {
        public static Kaffeemaschine Kaffeemaschine1 = new Kaffeemaschine();

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"

        };

        private readonly ILogger<KaffeeController> _logger;

        public KaffeeController(ILogger<KaffeeController> logger)
        {
            _logger = logger;
        }


        [HttpPut, Route("Kaffee auffüllen")]

        public double wasserAuffuellen(double menge)
        {
            double fuellmenge = 0;
            double wasser = Kaffeemaschine1.wasser;
            if (wasser + menge < 2.5)
                 fuellmenge = menge;
            else
                fuellmenge = 2.5 - wasser;
            Kaffeemaschine1.wasser = Kaffeemaschine1.wasser + fuellmenge;
            return fuellmenge;

        }

        [HttpPut, Route("Bohnen auffüllen")]
        

        public double bohnenAuffuellen(double menge)
        {

            double fuellmenge = 0;
            double bohnen = Kaffeemaschine1.bohnen;
            if (bohnen + menge < 2.5)
                fuellmenge = menge;
            else
                fuellmenge = 2.5 - bohnen;
            Kaffeemaschine1.bohnen = Kaffeemaschine1.bohnen + fuellmenge;
            return fuellmenge;
        }


        [HttpGet, Route("Kaffeemaschine")]


        public Kaffeemaschine kaffeemaschine()
        {

            return Kaffeemaschine1;
        }

        [HttpPut, Route("macheKaffee")]

        public bool macheKaffee(double menge, double verhaeltnisWasserBohnen)
        {
            double wasser = Kaffeemaschine1.wasser;
            double bohnen = Kaffeemaschine1.bohnen;
            double kaffeewasser = 0;
            double kaffeebohnen = 0;
            bool macheKaffee;
            if(verhaeltnisWasserBohnen == 0.5) {
                kaffeewasser = menge / 3;
                kaffeebohnen = (menge / 3)*2;


                if (kaffeebohnen > bohnen)
                {
                    macheKaffee = false;
                    return macheKaffee;
                }

                if (kaffeewasser > wasser)
                {
                    macheKaffee = false;
                    return macheKaffee;
                }

                Kaffeemaschine1.wasser = Kaffeemaschine1.wasser - kaffeewasser;
                Kaffeemaschine1.bohnen = Kaffeemaschine1.bohnen - kaffeebohnen;
                Kaffeemaschine1.gesamtMengeKaffeProduziert += menge;

                macheKaffee = true;
                return macheKaffee;


            }

            if (verhaeltnisWasserBohnen == 1) {
                kaffeewasser = menge / 2;
                kaffeebohnen = menge / 2;


                if (kaffeebohnen > bohnen)
                {
                    macheKaffee = false;
                    return macheKaffee;
                }

                if (kaffeewasser > wasser)
                {
                    macheKaffee = false;
                    return macheKaffee;
                }

                Kaffeemaschine1.wasser = Kaffeemaschine1.wasser - kaffeewasser;
                Kaffeemaschine1.bohnen = Kaffeemaschine1.bohnen - kaffeebohnen;
                Kaffeemaschine1.gesamtMengeKaffeProduziert += menge;

                macheKaffee = true;
                return macheKaffee;

            }





            if (verhaeltnisWasserBohnen == 2) {
                kaffeebohnen = menge / 3;
                kaffeewasser = (menge / 3) * 2;

                if (kaffeebohnen > bohnen) {
                    macheKaffee = false;
                    return macheKaffee;
                }

                if (kaffeewasser > wasser)
                {
                    macheKaffee = false;
                    return macheKaffee;
                }

                Kaffeemaschine1.wasser = Kaffeemaschine1.wasser - kaffeewasser;
                Kaffeemaschine1.bohnen = Kaffeemaschine1.bohnen - kaffeebohnen;
                Kaffeemaschine1.gesamtMengeKaffeProduziert += menge;

                macheKaffee = true;
                return macheKaffee;


            }
            macheKaffee = false;
            return macheKaffee;
        }
    }
}