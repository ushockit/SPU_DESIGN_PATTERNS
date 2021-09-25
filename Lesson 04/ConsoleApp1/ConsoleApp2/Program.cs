using System;

namespace ConsoleApp2
{
    enum PaymentType
    {
        CASH,
        GPAY,
        APPLE_PAY
    }
    struct PaymentRequest
    {
        public decimal Total { get; set; }
        public PaymentType Type { get; set; }

    }
    abstract class BaseHandler
    {
        protected BaseHandler _next;

        public void SetNext(BaseHandler handler) => _next = handler;
        public abstract void Handle(PaymentRequest request);
    }


    class CashPaymentHandler : BaseHandler
    {
        public override void Handle(PaymentRequest request)
        {
            if (request.Type == PaymentType.CASH)
            {
                // TODO: Handle of the CASH request
                Console.WriteLine("Handled with CASH...");
            }
            else
            {
                // Передача запроса по цепочке
                _next.Handle(request);
            }
        }
    }

    class GPayPaymentHandler : BaseHandler
    {
        public override void Handle(PaymentRequest request)
        {
            if (request.Type == PaymentType.GPAY)
            {
                Console.WriteLine("Handled with GPAY...");
            }
            else
            {
                // Передача запроса по цепочке
                _next.Handle(request);
            }
        }
    }

    class ApplePayPaymentHandler : BaseHandler
    {
        public override void Handle(PaymentRequest request)
        {
            if (request.Type == PaymentType.APPLE_PAY)
            {
                Console.WriteLine("Handled with ApplePay...");
            }
            else
            {
                _next.Handle(request);
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            PaymentRequest request = new PaymentRequest { Type = PaymentType.CASH, Total = 200 };

            CashPaymentHandler cashPaymentHandler = new CashPaymentHandler();
            GPayPaymentHandler gPayhandler = new GPayPaymentHandler();
            gPayhandler.SetNext(new ApplePayPaymentHandler());
            cashPaymentHandler.SetNext(gPayhandler);

            cashPaymentHandler.Handle(request);

            Console.WriteLine("Hello World!");
        }
    }
}
