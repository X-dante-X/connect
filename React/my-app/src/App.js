import logo from './logo.svg';
import './App.css';
import {useState} from 'react'
import Login from './components/Login/Login'
import { variables } from './Variables';
import axios from 'react'
import { useEffect } from 'react';
function App() {
  const [user, setUser] = useState(null)
  const [password, setPassword] = useState('')
  const [email, setEmail] = useState('')

  const handlePasswordChange = (event) =>{
    event.preventDefault()
    setPassword(event.target.value)
    console.log(password)
  }
  const handleEmailChange = (event) =>{
    event.preventDefault()
    setEmail(event.target.value)
    console.log(email)
  }
  const handleSignIn = async() =>{
    const recordBodyParameters = {
      'userLogin': email,
      'userPassword': password
    }
  
    const options = {
      method: 'POST',
      headers: {
        'accept': '*/*',
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(recordBodyParameters)
    }
  
    const response = await fetch('https://localhost:7226/api/UserSignin', options);
    const jsonResponse = await response.json();
    console.log(jsonResponse[0])
    return jsonResponse;
  }
  return (
    <div>
      <Login 
        handlePasswordChange={handlePasswordChange}
        password={password}
        handleEmailChange={handleEmailChange}
        email={email}
        handleSignIn={handleSignIn}>
      </Login>
    </div>
  );
}

export default App;