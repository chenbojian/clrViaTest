using BanKai.Basic.Common;
using BanKai.Basic.Extensions;
using FluentAssertions;
using Xunit;

namespace BanKai.Basic
{
    // ReSharper disable RedundantEmptyObjectOrCollectionInitializer
    // ReSharper disable UseObjectOrCollectionInitializer

    public class Classes
    {
        [Fact]
        public void should_choose_correct_overloading_method_at_compile_time_1()
        {
            var demoObject = new MethodOverloadDemoClass();

            string chosenOne = demoObject.Foo(1);

            // change variable value to correct one.
            const string expected = "Foo(int)";

            chosenOne.Should().Be(expected);
        }

        [Fact]
        public void should_choose_correct_overloading_method_at_compile_time_2()
        {
            var demoObject = new MethodOverloadDemoClass();

            string chosenOne = demoObject.Foo((object)1);

            // change variable value to correct one.
            const string expected = "Foo(object)";

            chosenOne.Should().Be(expected);
        }

        [Fact]
        public void should_choose_correct_overloading_method_at_compile_time_3()
        {
            var demoObject = new MethodOverloadDemoClass();

            const short argument = 2;
            string chosenOne = demoObject.Foo(argument);

            // change variable value to correct one.
            const string expected = "Foo(int)";

            chosenOne.Should().Be(expected);
        }

        [Fact]
        public void should_call_other_instance_constructor_in_overload_constructor()
        {
            var demoClass = new ConstructorOverloadingDemoClass("arg");

            string constructorCallSequence = demoClass.ConstructorCallSequence;
            
            // change variable value to correct one.
            const string expectedSequence = "Ctor()\r\nCtor(string)\r\n";//wtf...\r\n...

            constructorCallSequence.Should().Be(expectedSequence);
        }

        [Fact]
        public void should_generate_parameterless_constructor_by_default()
        {
            var demoClass = new ImplicitConstructorClassDemo();

            bool hasDefaultConstructor = demoClass.HasDefaultConstructor();

            // change variable value to correct one.
            const bool expected = true;

            hasDefaultConstructor.Should().Be(expected);
        }

        [Fact]
        public void should_not_generate_parameterless_constructor_if_parameterized_constructor_exists()
        {
            var demoClass = new ParameterizedConstructorClassDemo(1);

            bool hasDefaultConstructor = demoClass.HasDefaultConstructor();

            // change variable value to correct one.
            const bool expected = false;

            hasDefaultConstructor.Should().Be(expected);
        }

        [Fact]
        public void should_initailize_object_properties()
        {
            var demoClass = new ObjectInitializerDemoClass("property1")
            {
                // add property initialization logic here.
            };

            const string expectedProperty1 = "property1";
            const string expectedProperty2 = null;

            demoClass.Property1.Should().Be(expectedProperty1);
            demoClass.Property2.Should().Be(expectedProperty2);
        }

        [Fact]
        public void should_be_able_to_get_and_set_public_auto_properties()
        {
            var demoClass = new AutoPropertyDemoClass();

            demoClass.Name = "My Name";

            // please change variable value to correct one.
            const string expected = "My Name";

            demoClass.Name.Should().Be(expected);
        }

        [Fact]
        public void should_execute_customized_logic_in_property()
        {
            var demoClass = new CustomizePropertyDemoClass();

            demoClass.Name = "My Name";

            // please change variable value to correct one.
            const string expected = "Your Name Is My Name";

            demoClass.Name.Should().Be(expected);
        }

        [Fact]
        public void should_get_correct_value_of_indexer()
        {
            var demoClass = new IndexerDemoClass();

            string indexerValue = demoClass[2];

            // please change variable value to correct one.
            const string expected = "You are accessing indexer 2";

            indexerValue.Should().Be(expected);
        }

        [Fact]
        public void should_access_indexer_with_different_argument_type()
        {
            var demoClass = new IndexerDemoClass();

            string indexerValue = demoClass["stringArgument"];

            // please change variable value to correct one.
            const string expected = "You are accessing indexer stringArgument";

            indexerValue.Should().Be(expected);
        }

        [Fact]
        public void should_be_able_to_access_multiple_indexer_arguments()
        {
            var demoClass = new IndexerDemoClass();

            string indexerValue = demoClass[1, "Hello"];

            // please change variable value to correct one.
            const string expected = "You are accessing indexer with first argument 1 and second argument Hello";

            indexerValue.Should().Be(expected);
        }

        [Fact]
        public void should_do_static_initialization()
        {
            string staticFieldValue = StaticConstructorDemoClass.StaticField;

            // please change variable value to correct one.
            const string expected = "You are so cute!";

            staticFieldValue.Should().Be(expected);
        }

        [Fact]
        public void should_be_able_to_dispose_object_when_out_of_scope()
        {
            var disposable = new DisposableDemoClass();

            using (disposable)
            {
            }

            // please change variable value to correct one.
            const bool expected = true;

            disposable.IsDisposed.Should().Be(expected);
        }

        [Fact]
        public void should_be_able_to_declare_class_to_different_places()
        {
            var demoClass = new PartialClassDemoClass
            {
                Name = "Hall",
                Title = "Mr."
            };

            string name = demoClass.ToString();

            // please change variable value to correct one.
            const string expected = "Mr. Hall";

            name.Should().Be(expected);
        }
    }

    // ReSharper restore UseObjectOrCollectionInitializer
    // ReSharper restore RedundantEmptyObjectOrCollectionInitializer
}