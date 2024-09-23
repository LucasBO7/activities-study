export const RegisterForm = ({ onSubmitForm, user, setUser }) => {
    return (
        <form action={() => onSubmitForm(user)}>
            <label htmlFor="_userName">Username:</label>
            <input
                id="_userName"
                name="username"
                type="text"
                required
                value={user.name}
                onChange={(event) => setUser(...user, { name: event.target.value })}

            />

            <label htmlFor="_password">Senha:</label>
            <input
                id="_password"
                name="password"
                type="password"
                required
                value={user.password}
                onChange={(event) => setUser(...user, { password: event.target.value })}
            />

            <button type="submit">Cadastrar-se</button>
        </form>
    );
};



export const LoginForm = ({ onSubmitForm, user, setUser }) => {
    return (
        <form action={() => onSubmitForm(user)}>
            <label htmlFor="_userName">Username:</label>
            <input
                id="_userName"
                name="username"
                type="text"
                required
                value={user.name}
                onChange={(event) => setUser(...user, { name: event.target.value })}

            />

            <label htmlFor="_password">Senha:</label>
            <input
                id="_password"
                name="password"
                type="password"
                required
                value={user.password}
                onChange={(event) => setUser(...user, { password: event.target.value })}
            />

            <button type="submit">Logar-se</button>
        </form>
    );
};