using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private IList<Subscription> _subscriptions;
        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();

            AddNotifications(name, document, email);
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }        
        public Address Address { get; set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }

        //Procedimento referente ao principio OCP do Solid, 
        //que não permite alterações de fora da classe, mas que dispoe de métodos expansiveis para tal.
        public void AddSubscription(Subscription subscription)
        {
            
            var hasSubscriptionActive = false;
            foreach (var sub in _subscriptions)
            {
                if (sub.Active)
                    hasSubscriptionActive = true;
            }

            AddNotifications(new Contract()
                .Requires()
                .IsFalse(hasSubscriptionActive, "Student.Subscriptions", "Você já tem uma assinatura ativa")
                .AreNotEquals(0,subscription.Payments.Count, "Student.Subscriptions.Payments", "Essa assinatura não possui pagamentos")
            );

            if (Valid)
                _subscriptions.Add(subscription);

            // Alternativa
            //if (hasSubscriptionActive)
            //    AddNotification("Student.Subscriptions", "Você já tem uma assinatura ativa");
        }
    }
}