export const MessagesList = ({ messages }) => {
    return (
        !messages
            ? (<p>Não há mensagens enviadas!</p>)
            : (
                <ul>
                    {messages.map((item, index) => {
                        return <li key={index}>{item.username}: {item.msg}</li>
                    })}
                </ul>)
    );
}