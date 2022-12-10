import './Login.css'
function Login({handleEmailChange,email, handlePasswordChange, password, handleSignIn}){
    return(
        <div className="login_main">
            <div className="login_main_left"></div>
            <div className="login_main_right">
                <div className='login_main_right_wrap'>
                    <p className='login_main_right_title'>Sign In</p>
                    <form className='login_main_right_form'>
                        <label>Please enter your login details to sign in</label>
                        <input type='email' value={email} placeholder='Email adress' onChange={(event)=>handleEmailChange(event)}></input>
                        <input type='password' value={password} placeholder="Password" onChange={(event)=>handlePasswordChange(event)}></input>
                        <button onClick={handleSignIn}>Sign In</button>
                    </form>
                </div>
            </div>
        </div>
    )
}
export default Login