import logo from './logo.svg';
import './App.css';
import {useState} from 'react'
import Login from './components/Login/Login'
import { variables } from './Variables';

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
  const handleSignIn = () =>{
    if(password>0 && email.length>0)
    {
      fetch(variables.API_URL)
      .then((response) => response.json())
      .then((data) => console.log(data));
    }
    else{
      console.log("Login Error")
    }
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