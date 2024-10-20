import Card from "antd/es/card/Card";
import { CardTitle } from "./CardTitle";
import Button from "antd/es/button/button";

interface Props{
    singlets: Singlet[];
    handleDelete:(id: string) => void;
    handleOpen: (singlet: Singlet) => void;
}

export const Singlets = ({singlets, handleDelete, handleOpen}: Props) => {
    return (
        <div className="cards">
             {singlets.map((singlet : Singlet) =>(
                <Card
                 key={singlet.id}
                 title={<CardTitle title={singlet.title} price={singlet.price}/>}
                 bordered={false} 
                >
                    <p>{singlet.description}</p>
                    <div className="card__buttons">
                        <Button 
                            onClick={() => handleOpen(singlet)}
                            style={{flex: 1}}
                        >
                            Редактировать</Button>
                        <Button
                        onClick={() => handleDelete(singlet.id)}
                        danger
                        style={{flex: 1}}
                        >
                            Удалить</Button>
                    </div>
                </Card>
             ) )}
        </div>
    )
}