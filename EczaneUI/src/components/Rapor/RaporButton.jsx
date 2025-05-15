import { Button, Modal } from "antd";
import "./RaporButton.css"
import { useState } from "react";
import RaporForm from "./RaporForm";

const RaporButton = ({satislar, raporlar, setRaporlar}) => {
    const [isOpen, setIsOpen] = useState(false);

    return(
        <>
            <Button type="primary" variant="solid" color="blue"
            onClick={() => setIsOpen(true)}
            >Rapor Oluştur</Button>
            <Modal
            open={isOpen}
            footer={null}
            onClose={() => setIsOpen(false)}
            closable={false}
            >
                <RaporForm raporlar={raporlar} setRaporlar={setRaporlar} satislar={satislar} setIsOpen={setIsOpen}></RaporForm>
            </Modal>
        </>
    );
}

export default RaporButton;