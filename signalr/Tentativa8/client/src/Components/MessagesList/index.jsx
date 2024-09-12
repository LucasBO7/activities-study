export const MessagesList = ({ messages }) => {
    return (
        messages == []
            ? (<p>Não há mensagens enviadas!</p>)
            : (
                <ul>
                    {messages.map((item, index) => {
                        return <li key={index}>{item.user}: {item.text}</li>
                    })}
                </ul>)
    );
}