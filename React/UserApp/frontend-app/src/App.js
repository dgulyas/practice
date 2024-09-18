import React, { useState, useEffect } from 'react';
import axios from 'axios';

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
  const [serverUrl, setServerUrl] = useState('http://localhost:5022/users');
  const [users, setUsers] = useState([]);

  useEffect(() => {
    axios.get(serverUrl)
    .then(response => {
      setUsers(response.data);
    })
    .catch(error => {
      console.error(error);
    });
  }, [serverUrl]);

  //var mockUsers = [{"FirstName":"Stan","LastName":"War","MailingAddress":"123 Fake Street","EmailAddress":"aaaa@gmail.com"},{"FirstName":"Bob","LastName":"Peace","MailingAddress":"123 Real Street","EmailAddress":"bbcb@gmail.com"},{"FirstName":"Josh","LastName":"Stasis","MailingAddress":"123 Sureal Street","EmailAddress":"cccc@gmail.com"}];
  return (
    <div>
      <UserList users={users}/>
    </div>
  );
}

export default App;
