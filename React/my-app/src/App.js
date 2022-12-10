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
      fetch(variables.API_URL, {
      method: 'GET'
    })
    .then(response => response.json())
    .then(response => response.forEach(data => {

      if((data.password == password) && (data.login == email))
      {
        console.log(data.password)
        console.log(password)
        setUser(data)
        console.log("zalogowano! ")
        console.log(data)
      }
    }))
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