import { Button, Form, Input, InputNumber } from "antd";
import "./IlacAddForm.css";
import AddIlac from "../../api/AddIlac";
import GetIlaclar from "../../api/GetIlaclar";

const IlacAddForm = ({
  setModalOpen,
  isSuccess,
  setIsSuccess,
  setIlaclar,
  ilaclar,
}) => {
  const handleOnSubmit = async (values) => {
    const response = await AddIlac(values);
    if (response !== null) {
      console.log(response);
      const ilac = {
        id: response.id,
        adi: response.adi,
        fiyati: response.fiyati,
        stokDurumu: response.stokDurumu
      }
      setIlaclar([...ilaclar, ilac]);
      setIsSuccess(true);
    }
  };

  return (
    <>
      <Form onFinish={handleOnSubmit} style={{justifyContent:"center"}}>
        <Form.Item
          label="İlaç Adı"
          name="adi"
          style={{ width: "300px" }}
          rules={[
            { required: true, message: "İlaç adı girilmelidir" }
          ]}
        >
          <Input
            placeholder="ilac adi"
            required
            onChange={() => setIsSuccess(false)}
          ></Input>
        </Form.Item>
        <Form.Item
          label="Fiyat"
          name="fiyati"
          rules={[
            { required: true, message: "Fiyat girilmelidir" },
            {
              validator: (_, value) =>
                value > 0
                  ? Promise.resolve()
                  : Promise.reject("Fiyat 0'dan büyük olmalıdır"),
            },
          ]}
        >
          <InputNumber style={{width:"50px"}} placeholder="10" onChange={() => setIsSuccess(false)} />
        </Form.Item>

        <Form.Item
          label="Stok"
          name="stokDurumu"
          rules={[
            { required: true, message: "Stok girilmelidir" },
            {
              validator: (_, value) =>
                value > 0
                  ? Promise.resolve()
                  : Promise.reject("Stok 0'dan büyük olmalıdır"),
            },
          ]}
        >
          <InputNumber style={{width:"70px"}} placeholder="100" onChange={() => setIsSuccess(false)} />
        </Form.Item>

        <Button htmlType="submit" type="primary">
          İlaci Ekle
        </Button>
        <Button
          type="primary"
          danger
          onClick={() => {
            setModalOpen(false);
            setIsSuccess(false);
          }}
        >
          Çık
        </Button>
      </Form>
      {isSuccess ? <h1 color="green">İlac eklendi</h1> : <></>}
    </>
  );
};

export default IlacAddForm;
