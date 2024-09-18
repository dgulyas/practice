function User({user}){
  return(
    <li key={user}>
      FirstName: {user.FirstName}
    </li>
  );
}

function UserList({users}){
  const userList = users.map((userInstance, index) => {
    return ( <User user={userInstance}/> );
  });

  return(
    <ol>
      {userList}
    </ol>
  );
}

function App() {
  var mockUsers = [{"FirstName":"Stan","LastName":"War","MailingAddress":"123 Fake Street","EmailAddress":"aaaa@gmail.com"},{"FirstName":"Bob","LastName":"Peace","MailingAddress":"123 Real Street","EmailAddress":"bbcb@gmail.com"},{"FirstName":"Josh","LastName":"Stasis","MailingAddress":"123 Sureal Street","EmailAddress":"cccc@gmail.com"}];
  return (
    <div>
      <UserList users={mockUsers}/>
    </div>
  );
}

export default App;
