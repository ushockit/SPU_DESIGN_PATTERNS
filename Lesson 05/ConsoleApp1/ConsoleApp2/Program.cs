using System;

namespace ConsoleApp2
{
    abstract class BaseState
    {
        protected Phone _phone;
        public BaseState(Phone phone)
        {
            _phone = phone;
        }
        public abstract void Lock();
        public abstract void VolumeUp();
        public abstract void VolumeDown();
        public abstract void Touch();
    }

    class LockedState : BaseState
    {
        public LockedState(Phone phone) : base(phone)
        {
        }

        public override void Lock()
        {
            Console.WriteLine("Unlocked");
            _phone.ChangeState(new UnlockedState(_phone));
        }

        public override void Touch()
        {
            Console.WriteLine("Ignore. Phone is locked!");
        }

        public override void VolumeDown()
        {
            Console.WriteLine("Ignore...");
        }

        public override void VolumeUp()
        {
            Console.WriteLine("Ignore...");
        }
    }

    class UnlockedState : BaseState
    {
        public UnlockedState(Phone phone) : base(phone)
        {
        }
        public override void Lock()
        {
            Console.WriteLine("Locked");
            _phone.ChangeState(new LockedState(_phone));
        }

        public override void Touch()
        {
            Console.WriteLine("Opening the '...' app");
        }

        public override void VolumeDown()
        {
            Console.WriteLine("Volume Down");
        }

        public override void VolumeUp()
        {
            Console.WriteLine("Volume up");
        }
    }

    class OffState : BaseState
    {
        public OffState(Phone phone) : base(phone)
        {
        }
        public override void Lock()
        {
            Console.WriteLine("Phone on!");
            _phone.ChangeState(new LockedState(_phone));
        }

        public override void Touch()
        {
            Console.WriteLine("Ignore");
        }

        public override void VolumeDown()
        {
            Console.WriteLine("Ignore");
        }

        public override void VolumeUp()
        {
            Console.WriteLine("Ignore");
        }
    }

    class Phone
    {
        BaseState state;
        public Phone()
        {
            state = new OffState(this);
        }

        public void TapButtonLock()
        {
            state.Lock();
        }

        public void TouchScreen()
        {
            state.Touch();
        }

        public void TapVolumeButtonUp()
        {
            state.VolumeUp();
        }

        public void TapVolumeButtonDown()
        {
            state.VolumeDown();
        }

        public void ChangeState(BaseState state)
        {
            this.state = state;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Phone phone = new Phone();

            phone.TapButtonLock();

            phone.TapVolumeButtonDown();    // Ignore
            phone.TouchScreen();            // Ignore
            phone.TapButtonLock();          // Unlocked. Change state to Unlocked

            phone.TouchScreen();            // Opening app
            phone.TapVolumeButtonUp();      // Volume up
            phone.TapVolumeButtonUp();      // Volume up
            phone.TapButtonLock();          // Locked. Change state to locked

            phone.TapVolumeButtonDown();    // Ignore
            phone.TouchScreen();            // Ignore
        }
    }
}
