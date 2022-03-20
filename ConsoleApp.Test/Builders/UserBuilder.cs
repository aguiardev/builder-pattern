using ConsoleApp.Models;
using System;

namespace ConsoleApp.Test.Builders
{
    public class UserBuilder
    {
        private readonly UserModel _userModel;

        public UserBuilder()
            => _userModel = new UserModel();

        public UserBuilder AddId(int id)
        {
            _userModel.Id = id;
            return this;
        }

        public UserBuilder AddName(string name)
        {
            _userModel.Name = name;
            return this;
        }

        public UserBuilder AddBirth(DateTime birth)
        {
            _userModel.Birth = birth;
            return this;
        }

        public UserModel Build() => _userModel;
    }
}
